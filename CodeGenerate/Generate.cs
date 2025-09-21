using Common.Util;
using Model.Attributes;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerate
{
    public class Generate
    {
        public static void GenerateDto()
        {
            Console.WriteLine("代码生成中········");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDir = Path.GetFullPath(Path.Combine(baseDirectory, @"..\\..\\..\\..\\", @"Model\\Dto"));

            // JIT即时编译懒加载机制 --> 如果没有用到类库中的DLL中的类型不会加载到内存中
            //new User();
            //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //Assembly? assembly = assemblies.FirstOrDefault(x => x.GetName().Name == "Model");

            Assembly? assembly = Assembly.LoadFrom(Path.Combine(baseDirectory, "Model.dll"));

            if (assembly == null)
            {
                throw new Exception("Model包不存在!");
            }
            //创建目标文件夹
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }


            //加载模板文件
            string dtoTemplateText = File.ReadAllText("Templates/DtoTemplates.scriban");
            Template dtotemplate = Template.Parse(dtoTemplateText);


            //筛选目标实体
            Type[] types = assembly!.GetTypes();
            IEnumerable<Type> enumerable = types.Where(x => x.IsClass)
                .Where(x => x.Namespace != null && x.Namespace.StartsWith("Model.Table"))
                .Where(x => x.IsDefined(typeof(GenerateDtoAttribute), false));

            //遍历目标实体
            foreach (var type in enumerable)
            {
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => !x.PropertyType.IsClass || x.PropertyType == typeof(string)) // 导航属性筛选
                    .Select(x => new { name = x.Name, type = ReflectionUtils.ConvertCSharpTypeName(x.PropertyType) })  //转换类型 int64 --> long
                    .ToList();

                //渲染模板
                string fileText = dtotemplate.Render(new { className = type.Name + "Dto", properties = props });

                string fileName = Path.Combine(targetDir, $"{type.Name}Dto.cs");
                File.WriteAllText(fileName, fileText);
                Console.WriteLine($"生成: {fileName}");
            }

            Console.WriteLine("Dto生成完成!");

            Console.ReadLine();
        }
    }
}
