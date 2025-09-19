using Common.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Attributes;
using Model.Table.Authorize;
using ShanYue.Authorization.Handler;
using ShanYue.Context;
using ShanYue.Util;
using System.Linq.Expressions;
using System.Reflection;

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
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string baseDirectory1 = AppContext.BaseDirectory;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Assembly? assembly = assemblies.FirstOrDefault(x => x.GetName().Name == "Model");
            if(assembly == null)
            {
                throw new Exception("没有找到目标dll文件");
            }
            string modelDir = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\.."));
            //dto路径
            string targetDir = Path.Combine(modelDir, @"Model\Dto");
            if(!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            //扫描model的dll包
            Type[] types = assembly.GetTypes();
            List<Type> entityTypeList = types.Where(x => x.IsClass)
                .Where(x => x.Namespace != null && x.Namespace.StartsWith("Model.Table"))
                .Where(x => x.IsDefined(typeof(GenerateDtoAttribute), false)).ToList();
            foreach (var item in entityTypeList)
            {
                var dtoFileName = Path.Combine(targetDir, item.Name + "Dto.cs");
                using (var writer = new StreamWriter(dtoFileName, false))
                {
                    writer.WriteLine("using System;");
                    writer.WriteLine();
                    writer.WriteLine("namespace Model.Dto");
                    writer.WriteLine("{");
                    writer.WriteLine($"    public class {item.Name}Dto");
                    writer.WriteLine("    {");
                    //获取公共实例成员 并去除导航属性
                    var properties = item.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => !x.PropertyType.IsClass && x.PropertyType != typeof(string));
                    foreach (var property in properties)
                    {

                        writer.WriteLine($"        public {ReflectionUtils.ConvertCSharpTypeName(property.PropertyType)} {property.Name} {{ get; set;}}");
                    }
                    writer.WriteLine("    }");
                    writer.WriteLine("}");
                }
            }
            return "";
        }

        private async Task<string> SychonizeData()
        {
            List<Model.Table.Authorize.Module> modules = await blogContext.Modules.ToListAsync();
            List<Model.Table.Authorize.Module> list = modules.Select(x =>
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
            List<Model.Table.Authorize.Module> modules = await blogContext.Modules.ToListAsync();
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
