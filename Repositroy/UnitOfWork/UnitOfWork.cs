using Microsoft.EntityFrameworkCore.Storage;
using ShanYue.Context;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(BlogContext blogContext)
        {
            this.context = blogContext;
        }

        public async Task BeginTransaction()
        {
            if(context == null)
            {
                throw new InvalidOperationException("数据库上下文注入失败!");
            }
            _transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            if(_transaction == null)
            {
                throw new InvalidOperationException("事务尚未开启!");
            }
            try
            {
                await context.SaveChangesAsync();
                await _transaction!.CommitAsync();
            }catch(Exception ex)
            {
                await _transaction!.RollbackAsync();
                throw new InvalidOperationException("事务提交失败!" + ex.Message);
            }
        }
        public async Task RollBackTransaction()
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
            }
            if(context != null)
            {
                context.Dispose();
            }
        }

        
    }
}
