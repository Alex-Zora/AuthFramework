using Model.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepositroy<T> _dal;

        public BaseService(IBaseRepositroy<T> repositroy)
        {
            _dal = repositroy;
        }

        public async Task<int> Add(T entity)
        {
            return await _dal.Add(entity);
        }

        public async Task<int> BatchAdd(List<T> list)
        {
            return await _dal.BatchAdd(list);
        }

        public async Task<int> BatchDelete(List<T> list)
        {
            return await _dal.BatchDelete(list);
        }

        public async Task<int> BatchDelete(List<long> ids)
        {
            return await _dal.BatchDelete(ids);
        }

        public async Task<int> BatchUpdate(List<T> list)
        {
            return await _dal.BatchUpdate(list);
        }

        public async Task<int> DeleteById(long id)
        {
            return await _dal.DeleteById(id);
        }

        public async Task<List<T>> Query(Expression<Func<T, bool>>? whereExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null)
        {
            return await _dal.Query(whereExp, orderExp);
        }

        public Task<IQueryable<T>> Query()
        {
            return _dal.Query();
        }

        public async Task<List<T>> QueryAsNoTracking(Expression<Func<T, bool>>? whereExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null)
        {
            return await _dal.QueryAsNoTracking(whereExp, orderExp);
        }

        public async Task<T?> QueryById(long id)
        {
            return await _dal.QueryById(id);
        }

        public async Task<T?> QueryByIdAsNoTracking(long id)
        {
            return  await _dal.QueryByIdAsNoTracking(id);
        }

        public async Task<PageViewModel<T>> QueryPage(int currentPage = 1, int pageSize = 10, Expression<Func<T, bool>>? whereExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null)
        {
            return await _dal.QueryPage(currentPage, pageSize, whereExp, orderExp);
        }

        public async Task<int> Update(T entity)
        {
            return await _dal.Update(entity);
        }
    }
}
