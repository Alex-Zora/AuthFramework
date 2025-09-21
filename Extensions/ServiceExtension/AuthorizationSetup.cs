using Extensions.Authorization;
using Extensions.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.ServiceExtension
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthorization(options =>
            {
                //根据角色授权
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));

                //根据claims授权
                options.AddPolicy("DependcySidClaims", policy => policy.RequireClaim(ClaimTypes.Sid));
                options.AddPolicy("DependcyCustomClaims", policy => policy.RequireClaim("Custom"));

                //自定义授权策略
                options.AddPolicy(AuthPolicy.RBAC_NAME, policy =>
                {
                    policy.AddRequirements(new RolePermissionRequirement());
                });
            });
        }
    }
}
