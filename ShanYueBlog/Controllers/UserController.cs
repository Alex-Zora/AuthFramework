using Azure.Core;
using BlogApi.Authorization;
using Common.Cache;
using Common.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.ViewModel;
using Services.Interface;
using ShanYue.Cache;
using ShanYue.Context;
using ShanYue.Model;
using ShanYue.Model.ConfigModel;
using ShanYue.Util;
using StackExchange.Redis;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Role = ShanYue.Model.Role;

namespace ShanYue.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    [Authorize(AuthPolicy.RBAC_NAME)]
    public class UserController : ControllerBase
    { 
        private readonly IConfiguration _configuration;
        private readonly BlogContext _blogContext;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IRedisService redisService;

        public UserController(IConfiguration configuration, BlogContext blogContext, IConnectionMultiplexer connectionMultiplexer, IRedisService redisService)
        {
            _configuration = configuration;
            _blogContext = blogContext;
            _connectionMultiplexer = connectionMultiplexer;
            this.redisService = redisService;
        }

        private string GenerateToken(User user)
        {
            //查询出该用户所有的角色 然后存入claim中
            JwtConfig? jwtConfig = _configuration.GetSection("JwtConfig").Get<JwtConfig>();
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim("name", user.NickName));
            claims.Add(new Claim("email", user.Email ?? "3306@gmail.com"));
            claims.Add(new Claim("tokenVersion", user.TokenVersion.ToString()));
            foreach (var item in user!.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Role!.Name));
            }
            return JwtUtils.CreateJwtSecurityByDecriptor(claims, DateTime.Now.AddMinutes(30), jwtConfig!.AccessToken.SecretKey, jwtConfig.AccessToken.Issuer, jwtConfig.AccessToken.Audience);
        }

        private void LoopNaviBarAppendChildren(List<NavigationBar> all, NavigationBar curItem)
        {
            var subItems = all.Where(ee => ee.pid == curItem.id).ToList();

            if (subItems.Count > 0)
            {
                curItem.children = new List<NavigationBar>();
                curItem.children.AddRange(subItems);
            }
            else
            {
                curItem.children = null;
            }


            foreach (var subItem in subItems)
            {
                LoopNaviBarAppendChildren(all, subItem);
            }
        }

        [HttpGet]
        [EnableRateLimiting("LoginLimit")]
        [AllowAnonymous]
        public async Task<ResponseResult<TokenModel>> Login(string username, string password)
        {
            var user = await _blogContext.User.Where(x => username.Equals(x.Account)).FirstOrDefaultAsync();
            if(user == null)
            {
                return new ResponseResult<TokenModel> { message = "用户不存在!"};
            }
            //校验密码
            bool passCorrect = HashPasswordUtils.ParsePassword(password, Convert.FromBase64String(user.PasswordSalt!), user.Password);
            if(!passCorrect)
            {
                return new ResponseResult<TokenModel> { message = "密码错误!" };
            }
            string accessToken = "";
            TokenModel tokenModel = new TokenModel();
            if (user != null) 
            {
                IDatabase database = _connectionMultiplexer.GetDatabase();
                //查询redis是否缓存了所有的角色权限 如果没有则缓存
                if (!(await database.KeyExistsAsync("Role_Permission")))
                {
                    List<Role> roles = _blogContext.Role.Include(x => x.RolePermissions).ThenInclude(y => y.permission).ToList();
                    await PermissionCache.AllRolePermissionCache(database, roles);
                }

                IDatabase redisDatabase = _connectionMultiplexer.GetDatabase();

                //查询出该用户所有的角色 然后存入claim中
                User? users = await _blogContext.User.Include(x => x.UserRoles).ThenInclude(y => y.Role).Where(x => x.Id == user.Id).FirstOrDefaultAsync();

                //accessToken这里设置了30分钟 方便调试 正式环境设置短一点
                accessToken = GenerateToken(users!);
                //refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
                Common.Cache.RefreshToken refreshTokenCache = new Common.Cache.RefreshToken
                {
                    Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)),
                    UserId = user.Id,
                    ExpireDate = DateTime.Now.AddDays(3)
                };
                //删除redis中该用户旧的refreshtoken
                await redisService.RemoveListElementAsync<Common.Cache.RefreshToken>("RefreshToken", x => x.UserId == user.Id);
                await redisDatabase.ListRightPushAsync("RefreshToken", JsonSerializer.Serialize(refreshTokenCache));

                tokenModel.AccessToken = accessToken;
                tokenModel.RefreshToken = refreshTokenCache.Token;
            }
            return new ResponseResult<TokenModel>
            {
                message = "登录成功!",
                response = tokenModel
            };
        }

        [EnableRateLimiting("RefreshLimit")]
        [HttpPost]
        public async Task<ResponseResult<TokenModel>> RefreshToken(TokenModel tokenModel)
        {
            ResponseResult<TokenModel> responseResult = new ResponseResult<TokenModel>();
            IDatabase redisDatabase = _connectionMultiplexer.GetDatabase();
            RedisValue[] refreshList = await redisDatabase.ListRangeAsync("RefreshToken");

            Common.Cache.RefreshToken? refreshToken = refreshList.Select(x => JsonSerializer.Deserialize<Common.Cache.RefreshToken>(x!)).FirstOrDefault(x => x!.Token == tokenModel.RefreshToken);
            if(refreshToken != null)
            {
                //校验refreshToken
                Common.Cache.RefreshToken refreshTokenCache = await redisService.GetListElementAsync<Common.Cache.RefreshToken>("RefreshToken", x => x.Token.Equals(refreshToken));
                if(refreshTokenCache == null)
                {
                    responseResult.message = "RefreshToken非法!";
                    responseResult.code = 400;
                    return responseResult;
                } else if(refreshToken.ExpireDate >= DateTime.Now)
                {
                    responseResult.message = "RefreshToken已过期!请重新登录";
                    responseResult.code = 401;
                    return responseResult;
                }

                //颁发新的AccessToken和RefreshToken
                User? user = await _blogContext.User.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == refreshTokenCache.UserId);
                if (user != null)
                {
                    responseResult.response = new TokenModel
                    {
                        AccessToken = GenerateToken(user),
                        RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64))
                    };
                    //删除cache中用户的旧refreshToken 并存入新的refreshtoken
                    await redisService.RemoveListElementAsync<Common.Cache.RefreshToken>("RefreshToken", x => x.Token == refreshTokenCache.Token);
                    Common.Cache.RefreshToken refreshCache = new Common.Cache.RefreshToken
                    {
                        Token = responseResult.response.RefreshToken,
                        ExpireDate = DateTime.Now.AddDays(3),
                    };
                    await redisDatabase.ListRightPushAsync("RefreshToken", JsonSerializer.Serialize(refreshCache));
                }
            }
            return responseResult;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ResponseResult<UserInfo>> GetUserInfo()
        {
            UserInfo userInfo = new UserInfo();
            Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(claim != null)
            {
                User? user = await _blogContext.User.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(claim.Value));
                List<long> userRoles = user!.UserRoles.Select(x => x.RoleId).ToList();
                List<Role> role = await _blogContext.Role.
                    Include(x => x.RolePermissions).ThenInclude(x => x.permission)
                    //.Include(x => x.RolePermissions).ThenInclude(x => x.module)
                    .Where(x => userRoles.Contains(x.Id)).ToListAsync();
                if(user != null)
                {
                    userInfo.Id = user.Id;
                    userInfo.NickName = user.NickName;
                    userInfo.Name = user.Name;
                    userInfo.Email = user.Email;
                    userInfo.Role = string.Join(",", user.UserRoles.Select(x => x.Role!.Name));
                }
            }
            return new ResponseResult<UserInfo>
            {
                message = "获取成功!",
                response = userInfo
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ResponseResult<NavigationBar>> GetNavigation()
        {
            List<NavigationBar> navigationBars = new ();
            Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            List<UserRoleTable> userRoleTables = await _blogContext.UserRoleTable.Include(x => x.Role)
                .ThenInclude(x => x.RolePermissions.Where(x => x.ModuleId > 0))
                .ThenInclude(x => x.module)
                .Where(x => x.UserId == Convert.ToInt64(claim!.Value)) //Convert.ToInt64(claim!.Value)
                .ToListAsync();

            //获取该用户的路由模块
            foreach (var item in userRoleTables)
            {
                foreach (var moduleItem in item.Role!.RolePermissions)
                {
                    //如果为空
                    if(navigationBars.FirstOrDefault(x => x.id == moduleItem.ModuleId) == null)
                    {
                        var navigationItem = new NavigationBar
                        {
                            id = moduleItem.module.Id,
                            name = moduleItem.module.Name,
                            pid = moduleItem.module.ParentId,
                            order = moduleItem.module.OrderSort,
                            path = moduleItem.module.Code,
                            iconCls = moduleItem.module.Icon,
                            Func = moduleItem.module.Func,
                            IsHide = (bool)moduleItem.module.IsHide,
                            IsButton = moduleItem.module.IsButton,
                            meta = new NavigationBarMeta
                            {
                                icon = moduleItem.module.IconNew,
                                requireAuth = true,
                                title = moduleItem.module.Name,
                                NoTabPage = (bool)moduleItem.module.IsHide,
                                keepAlive = (bool)moduleItem.module.IsKeepAlive
                            }
                        };
                        navigationBars.Add(navigationItem);
                    }
                }
            }

            NavigationBar rootRoot = new NavigationBar()
            {
                id = 0,
                pid = 0,
                order = 0,
                name = "根节点",
                path = "",
                iconCls = "",
                meta = new NavigationBarMeta(),

            };

            //循环完成 转成树型结构
            LoopNaviBarAppendChildren(navigationBars, rootRoot);

            return new ResponseResult<NavigationBar>
            {
                message = "获取成功",
                response = rootRoot
            };
        }

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

        [AllowAnonymous]
        [HttpPut]
        public async Task<string> ModifyPassword(User user)
        {
            if(user != null && user.Id > 0)
            {
                //校验密码
                if (user.Password.Trim().IsNullOrEmpty())
                {
                    return "非法密码!";
                }
                User? data = await _blogContext.User.Where(x => x.Id == user.Id).FirstOrDefaultAsync(); 
                if(data != null)
                {
                    byte[] salt = HashPasswordUtils.GenerateSalt();
                    data.Password = HashPasswordUtils.Encryption(user.Password, salt);
                    data.PasswordSalt = Convert.ToBase64String(salt);
                    data.TokenVersion += 1;
                    _blogContext.User.Update(data);
                    _blogContext.SaveChanges();
                    return "修改成功!";
                }
            }
            return "操作失败";
        }
    }
}
