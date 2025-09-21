using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.ServiceExtension
{
    public static class BatchRegistSetup
    {
        /// <summary>
        /// service类库注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddServiceSetup(this IServiceCollection services)
        {
            //如果不使用泛型接口接收子类 则不需要注册
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.Scan(scan => scan.FromAssembliesOf(typeof(IBaseService<>))
            .AddClasses(x => x.Where(y => y.Name.EndsWith("Services")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }

        /// <summary>
        /// repositroy类库注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositorySetup(this IServiceCollection services)
        {
            //如果不使用泛型接口接收子类 则不需要注册
            services.AddScoped(typeof(IBaseRepositroy<>), typeof(BaseRepository<>));

            services.Scan(scan => scan.FromAssembliesOf(typeof(IBaseRepositroy<>))
            .AddClasses(x => x.Where(y => y.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
