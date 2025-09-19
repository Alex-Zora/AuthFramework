using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Serilog;
using Services;
using Services.Interface;
using ShanYue.Authorization.Handler;
using ShanYue.Authorization.Requirement;
using ShanYue.Context;
using ShanYue.Model.ConfigModel;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//注册Services类库
builder.Services.Scan(scan => scan.FromAssembliesOf(typeof(IRedisService))
    .AddClasses(c => c.Where(x => x.Name.EndsWith("Service")))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

//注册Repository类库
builder.Services.Scan(scan => scan.FromAssembliesOf(typeof(IBaseRepositroy<>))
    .AddClasses(c => c.Where(x => x.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddScoped(typeof(IBaseRepositroy<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

//serilog日志配置
builder.Logging.ClearProviders();
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

//swagger配置
builder.Services.AddSwaggerGen(options =>
{
    //swagger携带token验证
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "前缀为Bearer",
        Name = "test",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
});

//efcore配置
builder.Services.AddDbContext<BlogContext>(options =>
{
    new IdentityOptions();
    //options.UseInMemoryDatabase("ShanyueBlog");
    options.UseSqlServer("Server=localhost;Database=shanyue;Trusted_Connection=True;TrustServerCertificate=True;")
    //.LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableServiceProviderCaching();
});

//添加redis连接实例
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

//jwt鉴权
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //全局默认认证方式为Bearer
    .AddJwtBearer(options =>
    {
        var jwtConfig = configuration.GetRequiredSection("JwtConfig").Get<JwtConfig>() ?? throw new InvalidOperationException("文件没有配置JwtConfig节点");
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
                if(!context.Response.HasStarted)
                {
                    return context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new { Code = 403, msg = "无权访问该资源" }));
                }
                return Task.CompletedTask;
            }
        };
    });

//注册自定义授权策略
builder.Services.AddScoped<IAuthorizationHandler, RolePermissionHandler>();

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

