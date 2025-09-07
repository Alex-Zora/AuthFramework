using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBaseService<T> where T : class
    {
        Task<int> Add(T entity);
        /// <summary>
        /// 使用雪花id 不依赖数据库生成id 所以使用AddRange方法提升效率
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<int> BatchAdd(List<T> list);
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(T entity);
        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<int> BatchUpdate(List<T> list);
        /// <summary>
        /// 根据id删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteById(long id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<int> BatchDelete(List<T> list);
        /// <summary>
        /// 根据ids批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<int> BatchDelete(List<long> ids);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereExp"></param>
        /// <param name="orderExp"></param>
        /// <returns></returns>
        Task<PageViewModel<T>> QueryPage(int currentPage = 1, int pageSize = 10, Expression<Func<T, bool>>? whereExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> QueryById(long id);
        /// <summary>
        /// 根据id查询 不跟踪堆栈
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> QueryByIdAsNoTracking(long id);
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereExp"></param>
        /// <param name="orderExp"></param>
        /// <returns></returns>
        Task<List<T>> Query(Expression<Func<T, bool>>? whereExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null);
        /// <summary>
        /// 根据条件查询 不跟踪堆栈
        /// </summary>
        /// <param name="whereExp"></param>
        /// <param name="orderExp"></param>
        /// <returns></returns>
        Task<List<T>> QueryAsNoTracking(Expression<Func<T, bool>>? whereExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null);
    }
}
