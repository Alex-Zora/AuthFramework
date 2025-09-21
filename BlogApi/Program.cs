using BlogApi.Config;
using Extensions.Authentication;
using Extensions.ServiceExtension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using ShanYue.Authorization.Handler;
using ShanYue.Authorization.Requirement;
using ShanYue.Context;
using System.Text;
using System.Text.Json;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//automapper注册
builder.Services.AddAutoMapperSetup();

//注册Services类库
builder.Services.AddServiceSetup();
//注册Repository类库
builder.Services.AddRepositorySetup();

//serilog日志配置
builder.Logging.ClearProviders();
#region
builder.Host.UseSerilog((context, services, config) =>
{
    config.ReadFrom.Configuration(context.Configuration); // 读取 appsettings.json的Serilog配置
});
//builder.Services.AddSerilog((context, option) =>
//{
//    option.MinimumLevel.Information() // 全局 Information级别
//        // 保持 Hosting.Lifetime 日志为 Information（不要提升到 Warning）
//        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
//        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
//        .WriteTo.Console();
//});



//不需要添加任何操作  .net默认继承控制台日志provider 如果想清除默认的loggingprovider 使用builder.logging.ClearProviders()
//builder.Services.AddLogging(builder =>
//{
//    //var loggingConfigure = configuration.GetSection("Logging");

//    //builder.AddConfiguration(loggingConfigure);
//    //builder.AddConsole();
//});
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.SignIn.RequireConfirmedEmail = true;
//});
#endregion

//swagger配置
builder.Services.AddSwaggerSetup();

//efcore注入
builder.Services.AddDbContextSetup(configuration.GetConnectionString("default") ?? throw new ArgumentNullException("数据库连接字符串不可为空"));

//添加redis连接实例
builder.Services.AddRedisSetup(configuration.GetValue<string>("Redis") ?? throw new ArgumentNullException("redis连接字符串不可为空"));

//jwt鉴权
builder.Services.AddAuthenticationSetup(configuration.GetRequiredSection("JwtConfig").Get<JwtConfig>());

//注册自定义授权策略
builder.Services.AddAuthorizationSetup();
//builder.Services.AddScoped<IAuthorizationHandler, RolePermissionHandler>();

//添加授权服务
builder.Services.AddAuthorization(option =>
{
    //添加到自定义授权策略
    option.AddPolicy("RBAC", policy =>
    {
        policy.Requirements.Add(new RolePermissionRequirement());
    });
});

//注册接口限流中间件
builder.Services.AddRateLimiter(options =>
{
    //登录接口策略
    options.AddPolicy("LoginLimit", context =>
    {
        string userIP = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
        return RateLimitPartition.GetTokenBucketLimiter(userIP, _ =>
        {
            return new TokenBucketRateLimiterOptions
            {
                TokenLimit = 5,     //单个用户每分钟5次  取决于根据令牌捅里面的剩余的令牌
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,    //先进来的请求先处理
                QueueLimit = 0,     //设置排队队列0 意味超过5个请求超过直接拒绝
                TokensPerPeriod = 5,    //每分钟补充5个令牌
                ReplenishmentPeriod = TimeSpan.FromMinutes(1), //补充周期1分钟
                AutoReplenishment = true,    //自动补充
            };
        });
    });

    //令牌刷新接口策略
    options.AddPolicy("RefreshLimit", context =>
        RateLimitPartition.GetTokenBucketLimiter(context.Connection.RemoteIpAddress, _ =>
            new TokenBucketRateLimiterOptions
            {
                TokenLimit = 3,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 0,
                TokensPerPeriod = 3,
                ReplenishmentPeriod = TimeSpan.FromMinutes(1),
                AutoReplenishment = true,
            }));

    options.OnRejected = (context, cancellationToken) =>
    {
        if (!context.HttpContext.Response.HasStarted)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

            return new ValueTask(context.HttpContext.Response.WriteAsJsonAsync(new
            {
                Code = 429,
                Message = "请求频繁, 请稍后再试!"
            }, cancellationToken));
        }
        context.HttpContext.Abort();
        return ValueTask.CompletedTask;
    };
});

var app = builder.Build(); 

//app.UseSerilogRequestLogging();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseRateLimiter();

app.Run();


//使用identity的注册、登录等方法， 保护了这些方法 也就是login regist等方法需要验证授权
//app.MapIdentityApi<IdentityUser>();
//如果要保护某个api 调用RequireAuthorization方法  举例如下
//app.MapGet("/articleDetails", (HttpContext context) =>
//{
//    return "这是一篇文章";
//}).WithName("getDetails");
//.RequireAuthorization();

//app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager, [FromBody] object empty) =>
//{
//    if (empty != null)
//    {
//        await signInManager.SignOutAsync();
//        return Results.Ok();
//    }
//    return Results.Unauthorized();
//}).RequireAuthorization();


//保护swagger ui
/*app.MapSwagger().RequireAuthorization();*/

