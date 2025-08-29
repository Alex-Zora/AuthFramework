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
            var user = await _blogContext.User.Where(x => username.Equals(x.Account) && password.Equals(x.Password)).FirstOrDefaultAsync();
            string token = "";
            //查询该用户是否在redis中是否有有效的token 如果有 直接返回token 否则生成token
            if (user != null) 
            {
                //查询redis是否缓存了所有的角色权限 如果没有则缓存
                await PermissionCache.AllRolePermissionCache(_connectionMultiplexer, _blogContext);

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

        [Authorize("RBAC")]
        [HttpGet]
        public Task<string> test()
        {
            return Task.FromResult("token认证成功");
        }
    }
}
