using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShanYue.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.ServiceExtension
{
    public static class DbContextSetup
    {
        public static void AddDbContextSetup(this IServiceCollection services, string connStr = "")
        {
            if(services == null) throw new ArgumentNullException(nameof(services));

            if(string.IsNullOrWhiteSpace(connStr)) throw new ArgumentNullException("连接字符串不可为空");

            services.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(connStr)
                //.LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableServiceProviderCaching()
                .EnableSensitiveDataLogging();
            });
        }
    }
}
