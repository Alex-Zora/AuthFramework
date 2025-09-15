using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Util
{
    public class ReflectionUtils
    {
        public static string ConvertCSharpTypeName(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // 处理可空类型，例如 Int32?
                return ConvertCSharpTypeName(type.GetGenericArguments()[0]) + "?";
            }

            // 基本类型名映射
            var typeNameMap = new Dictionary<Type, string>
    {
        { typeof(int), "int" },
        { typeof(long), "long" },
        { typeof(short), "short" },
        { typeof(string), "string" },
        { typeof(bool), "bool" },
        { typeof(byte), "byte" },
        { typeof(decimal), "decimal" },
        { typeof(double), "double" },
        { typeof(float), "float" },
        { typeof(DateTime), "DateTime" },
        { typeof(Guid), "Guid" },
        // 更多你需要映射的类型
    };

            if (typeNameMap.ContainsKey(type))
            {
                return typeNameMap[type];
            }

            // 对于其他类型，返回其全名
            return type.Name;
        }
    }
}
