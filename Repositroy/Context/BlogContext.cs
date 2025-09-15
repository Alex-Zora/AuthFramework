using Microsoft.EntityFrameworkCore;
using Model.Attributes;
using Model.Table;
using Model.Table.Authorize;
using Repository.Context;
using ShanYue.Util;
using System.Reflection;

namespace ShanYue.Context
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class BlogContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermissionTable> RolePermissionTable { get; set; }
        public DbSet<UserRoleTable> UserRoleTable { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Basicparameter> Basicparameters { get; set; }
        public DbSet<Model.Table.Authorize.Module> Modules { get; set; }
        //public DbSet<Router> Routers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRoleTable>().HasOne<User>(x => x.User).WithMany(y => y.UserRoles).HasForeignKey(z => z.UserId);
            builder.Entity<UserRoleTable>().HasOne<Role>(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(z => z.RoleId);


            builder.Entity<RolePermissionTable>(entity =>
            {
                entity.HasOne<Role>(x => x.role).WithMany(y => y.RolePermissions).HasForeignKey(z => z.RoleId);
                entity.HasOne<Permission>(x => x.permission).WithMany(y => y.RolePermissions).HasForeignKey(z => z.PermissionId);
                entity.HasOne<Model.Table.Authorize.Module>(x => x.module).WithMany(x => x.RolePermissions).HasForeignKey(x => x.ModuleId);
            });

            builder.Entity<Basicparameter>().Ignore(x => x.Parent).Ignore(x => x.Children);


            //生成种子数据
            DbSeed.GenerateDbSeed(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("ShanyueBlog");
        }

        public override int SaveChanges()
        {
            foreach(var item in ChangeTracker.Entries())
            {
                if(item.State == EntityState.Added)
                {
                    PropertyInfo? propertyInfo = item.Entity.GetType()
                        .GetProperties()
                        .FirstOrDefault(x => x.GetCustomAttribute<SnowflakeIdAttribute>() != null);
                    if(propertyInfo != null && (long)(propertyInfo.GetValue(item.Entity) ?? 0) != 0)
                    {
                        propertyInfo.SetValue(item.Entity, SnowflakeIdUtils.NextId());
                    }
                }
            }
            return base.SaveChanges();
        }

        /// <summary>
        /// 生成雪花id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.State == EntityState.Added)
                {
                    PropertyInfo? propertyInfo = item.Entity.GetType()
                        .GetProperties()
                        .FirstOrDefault(x => x.GetCustomAttribute<SnowflakeIdAttribute>() != null);
                    if (propertyInfo != null && (long)(propertyInfo.GetValue(item.Entity) ?? 0) == 0)
                    {
                        propertyInfo.SetValue(item.Entity, SnowflakeIdUtils.NextId());
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        //这里是为了接受program.cs中注册时额外的配置
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
    }
}
