using Extensions.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Extensions.ServiceExtension
{
    public static class AuthenticationSetup
    {
        public static void AddAuthenticationSetup(this IServiceCollection services, JwtConfig? jwtConfig)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidIssuer = jwtConfig.AccessToken.Issuer,
                        ValidAudience = jwtConfig.AccessToken.Audience,
                        ClockSkew = TimeSpan.FromMinutes(1),  //默认允许5分钟时间差
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.AccessToken.SecretKey))
                    };


                    //添加token事件 
                    options.Events = new JwtBearerEvents
                    {
                        //token无效或者过期触发该事件
                        //OnAuthenticationFailed = context =>
                        //{
                        //    // 告诉后续 Challenge 要用哪个消息
                        //    context.HttpContext.Items["JwtError"] =
                        //        context.Exception is SecurityTokenExpiredException
                        //        ? "token expired"
                        //        : "token invalid";

                        //    // 取消默认处理，但不写 Response
                        //    context.NoResult();
                        //    return Task.CompletedTask;
                        //},
                        //此处为权限验证失败后触发的事件
                        OnChallenge = context =>
                        {
                            //此处代码为终止.Net Core默认的返回类型和数据结果，这个很重要
                            context.HandleResponse();
                            // 没有携带token
                            if (!context.Response.HasStarted)
                            {
                                context.HandleResponse();
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                //context.Response.ContentType = "application/json";
                                context.Response.Headers.Append("Token-Error", context.ErrorDescription);

                                return context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new
                                {
                                    Code = 401,
                                    msg = "请提供有效的认证token"
                                }));
                            }
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            if (!context.Response.HasStarted)
                            {
                                return context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new { Code = 403, msg = "无权访问该资源" }));
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

        }
    }
}
