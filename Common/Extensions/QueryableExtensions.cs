using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 根据条件添加表达式树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereIF<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> exp)where T:class
        {
            if(query == null) throw new ArgumentNullException(nameof(query));

            if(exp == null) throw new ArgumentNullException(nameof(exp));

            return condition ? query.Where(exp) : query;
        }

        /// <summary>
        /// 根据条件添加字段排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="exp"></param>
        /// <param name="descending">是否降序</param>
        /// <returns></returns>
        public static IQueryable<T> OrderByIF<T>(this IQueryable<T> query, bool condition, Expression<Func<T, PropertyInfo>> exp, bool descending = false)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (!condition) return query;
            return descending ? query.OrderByDescending(exp) : query.OrderBy(exp);
        }
    }
}
