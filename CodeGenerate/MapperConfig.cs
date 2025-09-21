using AutoMapper;
using Model.Table.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerate
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // 批量注册映射
            RegisterEntityDtoMappings();
        }

        private void RegisterEntityDtoMappings()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Assembly? assembly = Assembly.LoadFrom(Path.Combine(baseDirectory, "Model.dll"));

            if(assembly == null)
            {
                throw new FileNotFoundException("model.dll文件不存在");
            }
            var types = assembly.GetTypes();
            // 获取所有实体
            var entityTypes = types.Where(t => t.Namespace == "Model.Table");

            // 获取所有 DTO
            var dtoTypes = types.Where(t => t.Namespace == "Model.Dto");

            foreach (var entity in entityTypes)
            {
                var dtoName = entity.Name + "Dto";
                var dto = dtoTypes.FirstOrDefault(d => d.Name == dtoName);
                if (dto != null)
                {
                    CreateMap(entity, dto);   // AutoMapper 方法
                }
            }
        }
    }
}
