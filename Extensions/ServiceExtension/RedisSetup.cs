using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.ServiceExtension
{
    public static class RedisSetup
    {
        public static void AddRedisSetup(this IServiceCollection services, string conn = "")
        {
            if(services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(conn));
        }
    }
}
