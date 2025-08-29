using Microsoft.AspNetCore.Authorization;
using ShanYue.Authorization.Requirement;
using ShanYue.Cache;
using ShanYue.Model.Cache;
using StackExchange.Redis;
using System.Security.Claims;

namespace ShanYue.Authorization.Handler
{
    public class RolePermissionHandler : AuthorizationHandler<RolePermissionRequirement>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RolePermissionHandler(IConnectionMultiplexer connectionMultiplexer)
        {
            this._connectionMultiplexer = connectionMultiplexer;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolePermissionRequirement requirement)
        {
            if(context != null)
            {
                //获取上下文中用户claims的角色
                if(context.Resource is HttpContext httpContext)
                {
                    var claims = httpContext.User.Claims;
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

                }
            }
        }
    }
}
