using BlogApi.Authorization;
using Common.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShanYue.Cache;
using ShanYue.Context;
using ShanYue.Model;
using ShanYue.Model.ConfigModel;
using ShanYue.Util;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text;
using Role = ShanYue.Model.Role;

namespace ShanYue.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class UserController : ControllerBase
    { 
        private readonly IConfiguration _configuration;
        private readonly BlogContext _blogContext;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public UserController(IConfiguration configuration, BlogContext blogContext, IConnectionMultiplexer connectionMultiplexer)
        {
            _configuration = configuration;
            _blogContext = blogContext;
            _connectionMultiplexer = connectionMultiplexer;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<string> Login(string username, string password)
        {
            var user = await _blogContext.User.Where(x => username.Equals(x.Account)).FirstOrDefaultAsync();
            if(user == null)
            {
                return "用户不存在";
            }
            //校验密码
            bool passCorrect = HashPasswordUtils.ParsePassword(password, Convert.FromBase64String(user.PasswordSalt!), user.Password);
            if(!passCorrect)
            {
                return "密码错误";
            }
            string token = "";
            //查询该用户是否在redis中是否有有效的token 如果有 直接返回token 否则生成token
            if (user != null) 
            {
                IDatabase database = _connectionMultiplexer.GetDatabase();
                //查询redis是否缓存了所有的角色权限 如果没有则缓存
                if (!(await database.KeyExistsAsync("RolePermission")))
                {
                    List<Role> roles = _blogContext.Role.Include(x => x.RolePermissions).ThenInclude(y => y.permission).ToList();
                    await PermissionCache.AllRolePermissionCache(database, roles);
                }

                IDatabase redisDatabase = _connectionMultiplexer.GetDatabase();
                RedisValue tokenValue = await redisDatabase.StringGetAsync(user.Id + "-" + user.Name);
                if(tokenValue.HasValue)
                {
                    token = tokenValue.ToString();
                } else 
                {
                    //查询出该用户所有的角色 然后存入claim中
                    User? users = await _blogContext.User.Include(x => x.UserRoles).ThenInclude(y => y.Role).Where(x => x.Id == user.Id).FirstOrDefaultAsync();
                    JwtConfig? jwtConfig = _configuration.GetSection("JwtConfig").Get<JwtConfig>();
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("name", user.NickName));
                    claims.Add(new Claim("email", user.Email ?? "3306@gmail.com"));
                    foreach(var item in users!.UserRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Role!.Name));
                    }
                    token = JwtUtils.CreateJwtSecurityByDecriptor(claims, DateTime.Now.AddMinutes(30), jwtConfig!.SecretKey, jwtConfig.Issuer, jwtConfig.Audience);
                    //存入redis中 过期时间设置30分钟
                    bool v = redisDatabase.StringSet(user.Id + "-" + user.Name, token, TimeSpan.FromMinutes(30));
                } 
            }
            return token;
        }

        //[Authorize(policy: AuthPolicy.RBAC_NAME)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> Regist(User user)
        {
            if(user == null)
            {
                return "注册失败!";
            }
            if((await _blogContext.User.Where(x => x.Account == user.Account.Trim()).FirstOrDefaultAsync()) != null)
            {
                return "账号已存在!";
            }
            //得到盐值 使用Base64编码
            byte[] salt = HashPasswordUtils.GenerateSalt();
            user.PasswordSalt = Convert.ToBase64String(salt);
            //加密密码
            user.Password = HashPasswordUtils.Encryption(user.Password, salt);
            _blogContext.User.Add(user);
            int v = await _blogContext.SaveChangesAsync();
            return user.Id.ToString();
        }
    }
}
