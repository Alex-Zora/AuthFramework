using Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.ViewModel;
using ShanYue.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepositroy<T> where T : class, new()
    {
        private readonly BlogContext blogContext;
        private readonly DbSet<T> dbSet;
        private string primaryKeyName = string.Empty;
        /// <summary>
        /// 主键类型  暂时没用到 备用
        /// </summary>
        private Type? primaryKeyType = null;

        private void GetPrimaryKeyInfo()
        {
            IEntityType? entityType = blogContext.Model.FindEntityType(typeof(T));
            if (entityType == null)
            {
                throw new Exception(typeof(BlogContext).Name + $"上下文中不存在该{nameof(T)}实体");
            }
            IKey? key = entityType.FindPrimaryKey();
            if(key == null)
            {
                throw new Exception(entityType.Name + "实体没有定义主键!");
            }
            //因为主键可能有多个 这里默认返回第一个主键 所有的表都是用的单主键
            IProperty? property = key.Properties.FirstOrDefault();
            primaryKeyName = property!.Name;
            primaryKeyType = property.ClrType;
        }

        public BaseRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
            this.dbSet = blogContext.Set<T>();
            //获取主键信息
            GetPrimaryKeyInfo();
        }

        public async Task<int> Add(T entity)
        {
            blogContext.Add(entity);
            return await blogContext.SaveChangesAsync();
        }
        
        public async Task<int> BatchAdd(List<T> list)
        {
            blogContext.AddRange(list);
            return await blogContext.SaveChangesAsync();
        }
        public async Task<int> DeleteById(long id)
        {
            T? entity = await dbSet.FirstOrDefaultAsync(x => id == EF.Property<long>(x, primaryKeyName));
            if (entity == null) return 0;
            dbSet.Remove(entity);
            return await blogContext.SaveChangesAsync();
        }

        public async Task<int> BatchDelete(List<T> list)
        {
            blogContext.RemoveRange(list);
            return await blogContext.SaveChangesAsync();
        }

        public async Task<int> BatchDelete(List<long> ids)
        {
            return await dbSet.Where(x => ids.Contains(EF.Property<long>(x, primaryKeyName))).ExecuteDeleteAsync();
        }

        public async Task<int> Update(T entity)
        {
            dbSet.Update(entity);
            return await blogContext.SaveChangesAsync();
        }

        public async Task<int> BatchUpdate(List<T> list)
        {
            dbSet.UpdateRange(list);
            return await blogContext.SaveChangesAsync();
        }

        public async Task<int> Delete(long id)
        {
            return await dbSet.Where(x =>  id == EF.Property<long>(x, primaryKeyName)).ExecuteDeleteAsync();
        }

        public async Task<T?> QueryById(long id)
        {
            return await dbSet.FirstOrDefaultAsync(x => EF.Property<long>(x, primaryKeyName) == id);
        }
        public async Task<T?> QueryByIdAsNoTracking(long id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(x => id == EF.Property<long>(x, primaryKeyName));
        }

        public async Task<List<T>> Query(Expression<Func<T, bool>>? wherrExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null)
        {
            return await dbSet.WhereIF(wherrExp != null, wherrExp!)
                .OrderByIF(orderExp == null, orderExp!)
                .ToListAsync();
        }

        public async Task<List<T>> QueryAsNoTracking(Expression<Func<T, bool>>? wherrExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null)
        {
            return await dbSet.AsNoTracking()
                .WhereIF(wherrExp != null, wherrExp!)
                .OrderByIF(orderExp == null, orderExp!)
                .ToListAsync();
        }

        public async Task<PageViewModel<T>> QueryPage(int currentPage = 1, int pageSize = 10, Expression<Func<T, bool>>? wherrExp = null, Expression<Func<T, PropertyInfo>>? orderExp = null)
        {
            int skipCount = (currentPage - 1) * pageSize;
            PageViewModel<T> pageViewModel = new PageViewModel<T>
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = await dbSet.CountAsync(),
                
            };

            pageViewModel.PageData = await dbSet.WhereIF(wherrExp != null, wherrExp!)
                .OrderByIF(orderExp == null, orderExp!)
                .AsNoTracking()
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();

            return pageViewModel;
        }

        public Task<IQueryable<T>> Query()
        {
            return Task.FromResult(dbSet.Where(x => true));
        }
    }
}
