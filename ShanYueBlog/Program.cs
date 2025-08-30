using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using ShanYue.Authorization.Handler;
using ShanYue.Authorization.Requirement;
using ShanYue.Context;
using ShanYue.Model;
using ShanYue.Model.ConfigModel;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//serilog��־����
builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, services, config) =>
{
    config.ReadFrom.Configuration(context.Configuration); // ��ȡ appsettings.json��Serilog����
});
//builder.Services.AddSerilog((context, option) =>
//{
//    option.MinimumLevel.Information() // ȫ�� Information����
//        // ���� Hosting.Lifetime ��־Ϊ Information����Ҫ������ Warning��
//        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
//        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
//        .WriteTo.Console();
//});



//����Ҫ����κβ���  .netĬ�ϼ̳п���̨��־provider ��������Ĭ�ϵ�loggingprovider ʹ��builder.logging.ClearProviders()
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

//swagger����
builder.Services.AddSwaggerGen(options =>
{
    //swaggerЯ��token��֤
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "ǰ׺ΪBearer",
        Name = "test",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
});

//efcore����
builder.Services.AddDbContext<BlogContext>(options =>
{
    //options.UseInMemoryDatabase("ShanyueBlog");
    options.UseSqlServer("Server=localhost;Database=shanyue;Trusted_Connection=True;TrustServerCertificate=True;")
    //.LogTo(Console.WriteLine, LogLevel.Information)
    .EnableServiceProviderCaching();
});

//���redis����ʵ��
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

//jwt��Ȩ
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //ȫ��Ĭ����֤��ʽΪBearer
    .AddJwtBearer(options =>
    {
        var jwtConfig = configuration.GetRequiredSection("JwtConfig").Get<JwtConfig>() ?? throw new InvalidOperationException("�ļ�û������JwtConfig�ڵ�");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            ClockSkew = TimeSpan.FromMinutes(1),  //Ĭ������5����ʱ���
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey))
        };

        //���token�¼� 
        options.Events = new JwtBearerEvents
        {
            //token��Ч���߹��ڴ������¼�
            OnAuthenticationFailed = context =>
            {
                // ��ֹĬ�ϵĴ���
                context.NoResult();

                // �����Ӧ�Ƿ��Ѿ���ʼ
                if (true)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    //context.Response.ContentType = "application/json";
                    if(context.Exception.Message.Contains("expire", StringComparison.OrdinalIgnoreCase))
                    {
                        string msg = "token expired";

#if DEBUG
                        msg = msg + "," + context.Exception.Message;

#endif
                        if(!context.Response.HasStarted)
                        {
                            return context.Response.WriteAsJsonAsync(new { Code = 401, msg = msg });
                        }
                    }
                }
                return Task.CompletedTask;
            },
            //�˴�ΪȨ����֤ʧ�ܺ󴥷����¼�
            OnChallenge = context =>
            {
                //�˴�����Ϊ��ֹ.Net CoreĬ�ϵķ������ͺ����ݽ�����������Ҫ
                context.HandleResponse();
                // û��Я��token
                if (!context.Response.HasStarted)
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    //context.Response.ContentType = "application/json";
                    context.Response.Headers.Append("Token-Error", context.ErrorDescription);

                    return context.Response.WriteAsJsonAsync(new
                    {
                        Code = 401,
                        msg = "���ṩ��Ч����֤token"
                    });
                }
                return Task.CompletedTask;
            },
            OnForbidden = context =>
            {
                if(!context.Response.HasStarted)
                {
                    return context.Response.WriteAsJsonAsync(new { Code = 403, msg = "��Ȩ���ʸ���Դ" });
                }
                return Task.CompletedTask;
            }
        };
    });

//ע���Զ�����Ȩ����
builder.Services.AddScoped<IAuthorizationHandler, RolePermissionHandler>();

//�����Ȩ����
builder.Services.AddAuthorization(option =>
{
    //��ӵ��Զ�����Ȩ����
    option.AddPolicy("RBAC", policy =>
    {
        policy.Requirements.Add(new RolePermissionRequirement());
    });
});

var app = builder.Build(); 

//app.UseSerilogRequestLogging();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();


//ʹ��identity��ע�ᡢ��¼�ȷ����� ��������Щ���� Ҳ����login regist�ȷ�����Ҫ��֤��Ȩ
//app.MapIdentityApi<IdentityUser>();
//���Ҫ����ĳ��api ����RequireAuthorization����  ��������
//app.MapGet("/articleDetails", (HttpContext context) =>
//{
//    return "����һƪ����";
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


//����swagger ui
/*app.MapSwagger().RequireAuthorization();*/

