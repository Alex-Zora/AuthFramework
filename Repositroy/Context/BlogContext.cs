using Microsoft.EntityFrameworkCore;
using ShanYue.Model;
using ShanYue.Model.Authorize;
using ShanYue.Util;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRoleTable>().HasOne<User>(x => x.User).WithMany(y => y.UserRoles).HasForeignKey(z => z.UserId);
            builder.Entity<UserRoleTable>().HasOne<Role>(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(z => z.RoleId);


            builder.Entity<RolePermissionTable>(entity =>
            {
                entity.HasOne<Role>(x => x.role).WithMany(y => y.RolePermissions).HasForeignKey(z => z.RoleId);
                entity.HasOne<Permission>(x => x.permission).WithMany(y => y.RolePermissions).HasForeignKey(z => z.PermissionId);
            });

            //种子数据
            #region
            long user1Id = SnowflakeIdUtils.NextId();
            long user2Id = SnowflakeIdUtils.NextId();

            long role1Id = SnowflakeIdUtils.NextId();
            long role2Id = SnowflakeIdUtils.NextId();
            long role3Id = SnowflakeIdUtils.NextId();

            long permission1Id = SnowflakeIdUtils.NextId();
            long permission2Id = SnowflakeIdUtils.NextId();
            long permission3Id = SnowflakeIdUtils.NextId();
            long permission4Id = SnowflakeIdUtils.NextId();
            long permission5Id = SnowflakeIdUtils.NextId();

            User user1 = new User(user1Id, "dk", "山月", "shanyue", "mountainmono@gmail.com", DateTime.Now, DateTime.Now, "123456");
            User user2 = new User(user2Id, "kd", "雪村", "xuecun", "1906525910@gmail.com", DateTime.Now, DateTime.Now, "123456");

            Role role1 = new Role(role1Id, "管理员", DateTime.Now, DateTime.Now, "");
            Role role2 = new Role(role2Id, "普通用户", DateTime.Now, DateTime.Now, "");
            Role role3 = new Role(role3Id, "游客", DateTime.Now, DateTime.Now, "");

            Permission permission1 = new Permission(permission1Id, "文章添加", "/api/article/add", Code: "", DateTime.Now, DateTime.Now, "");
            Permission permission2 = new Permission(permission2Id, "文章删除", "/api/article/delete", Code: "", DateTime.Now, DateTime.Now, "");
            Permission permission3 = new Permission(permission3Id, "文章修改", "/api/article/update", Code: "", DateTime.Now, DateTime.Now, "");
            Permission permission4 = new Permission(permission4Id, "文章详情", "/api/article/GetDetail", Code: "", DateTime.Now, DateTime.Now, "");
            Permission permission5 = new Permission(permission5Id, "文章列表", "/api/article/Get", Code: "", DateTime.Now, DateTime.Now, "");

            builder.Entity<User>().HasData(user1, user2);
            builder.Entity<Role>().HasData(role1, role2, role3);
            builder.Entity<Permission>().HasData(permission1, permission2, permission3, permission4, permission5);

            builder.Entity<UserRoleTable>().HasData(new UserRoleTable
            {
                Id = SnowflakeIdUtils.NextId(),
                UserId = user1Id,
                RoleId = role1Id,
            }, new UserRoleTable
            {
                Id = SnowflakeIdUtils.NextId(),
                UserId = user2Id,
                RoleId = role2Id,
            }, new UserRoleTable
            {
                Id = SnowflakeIdUtils.NextId(),
                UserId = user1Id,
                RoleId = role2Id,
            });

            builder.Entity<RolePermissionTable>().HasData(new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role1Id,
                PermissionId = permission1Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role1Id,
                PermissionId = permission2Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role1Id,
                PermissionId = permission3Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role1Id,
                PermissionId = permission4Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role1Id,
                PermissionId = permission5Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role2Id,
                PermissionId = permission1Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role2Id,
                PermissionId = permission2Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role2Id,
                PermissionId = permission4Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role2Id,
                PermissionId = permission5Id,
            }, new RolePermissionTable
            {
                Id = SnowflakeIdUtils.NextId(),
                RoleId = role3Id,
                PermissionId = permission4Id,
            });
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("ShanyueBlog");
        }

        //这里是为了接受program.cs中注册时额外的配置
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
    }


    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;
    //    public string NickName { get; set; } = string.Empty;
    //    public string Password { get; set; } = string.Empty;
    //}
}
