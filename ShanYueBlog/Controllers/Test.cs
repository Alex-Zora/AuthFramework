using Common.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShanYue.Authorization.Handler;
using ShanYue.Context;
using ShanYue.Model;
using ShanYue.Util;
using System.Linq.Expressions;

namespace BlogApi.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly BlogContext blogContext;
        public TestController(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        [HttpGet]
        public async Task<string> test1()
        {
            //Expression<Func<User, bool>> expression = ExpressionFactory<User>.Create(x => x.CreateTime == DateTime.Now)
            //    .AndIF(1 == 1, x => x.UpdateTime == DateTime.Now);
            return "";
        }

        private async Task<string> SychonizeData()
        {
            List<ShanYue.Model.Module> modules = await blogContext.Modules.ToListAsync();
            List<ShanYue.Model.Module> list = modules.Select(x =>
            {
                x.Id = SnowflakeIdUtils.NextId();
                return x;
            }).ToList();
            blogContext.RemoveRange(modules);
            await blogContext.SaveChangesAsync();

            await blogContext.AddRangeAsync(list);
            await blogContext.SaveChangesAsync();
            return 1.ToString();
        }

        private async Task RoleModules()
        {
            List<ShanYue.Model.Module> modules = await blogContext.Modules.ToListAsync();
            List<RolePermissionTable> rolePermissionTables = new List<RolePermissionTable>();
            foreach (var item in modules)
            {
                rolePermissionTables.Add(new RolePermissionTable
                {
                    Id = SnowflakeIdUtils.NextId(),
                    RoleId = 1916916492496898,
                    ModuleId = item.Id
                });
            }
            blogContext.AddRange(rolePermissionTables);
            await blogContext.SaveChangesAsync();
        }
    }
}
