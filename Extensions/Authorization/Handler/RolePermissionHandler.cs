using Extensions.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Model.ViewModel;
using ShanYue.Cache;
using ShanYue.Context;
using ShanYue.Model;
using StackExchange.Redis;
using System.Net;
using System.Security.Claims;

namespace Extensions.Authorization.Handler
{
    public class RolePermissionHandler : AuthorizationHandler<RolePermissionRequirement>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly BlogContext _blogContext;

        public RolePermissionHandler(IConnectionMultiplexer connectionMultiplexer, BlogContext blogContext)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _blogContext = blogContext;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolePermissionRequirement requirement)
        {
            if(context != null)
            {
                //获取上下文中用户claims的角色
                if(context.Resource is HttpContext httpContext)
                {
                    var claims = httpContext.User.Claims;
                    //校验tokenVersion 不一致则token失效 这样做是为了用户多次登录颁发的获得的accesstoken只有最新的有效 登录时添加tokenVersion claim 所以这里可以确保clasim不为空消除警告
                    //Claim tokenVersionClaim = claims.FirstOrDefault(x => x.Type == "tokenVersion")!;
                    //Claim idClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!;
                    //查询该用户tokenVersion
                    //User? user = _blogContext.User.Where(x => x.Id == Convert.ToInt64(idClaim.Value)).FirstOrDefault();
                    //if(user == null || user.TokenVersion != Convert.ToInt64(tokenVersionClaim.Value))
                    //{
                    //    //返回401防止触发OnForbidden委托 OnForbidden委托代表权限不够
                    //    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    //    await httpContext.Response.WriteAsJsonAsync(new
                    //    {
                    //        Code = 401,
                    //        msg = "toekn版本失效, 请重新登录"
                    //    });
                    //    return;
                    //}

                    //查询当前上下文角色
                    List<string> roleClaims = claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
                    List<PermissionItem> permissionItems = new List<PermissionItem>();
                    //获取redis中对应的角色
                    foreach (var item in roleClaims)
                    {
                        List<PermissionItem> permList = await PermissionCache.GetRolePerssionCacheAsync(_connectionMultiplexer.GetDatabase(), "", item);
                        permissionItems.AddRange(permList);
                    }
                    //获取当前api路径作比较
                    var apiPath = httpContext.Request.Path;
                    foreach (var item in permissionItems)
                    {
                        bool v = item.Url!.Equals(apiPath.Value, StringComparison.OrdinalIgnoreCase);
                        if(v)
                        {
                            //成功则授权
                            context.Succeed(requirement);
                            return;
                        }
                    }
                    context.Fail();
                }
            }
        }
    }
}
