using Microsoft.EntityFrameworkCore;
using ShanYue.Model;
using ShanYue.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public sealed class DbSeed
    {
        /// <summary>
        /// 数据库种子数据
        /// </summary>
        /// <param name="builder"></param>
        public static void GenerateDbSeed(ModelBuilder builder)
        {
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

            Module module1 = new Module { Id = 0};

            builder.Entity<User>().HasData(user1, user2);
            builder.Entity<Role>().HasData(role1, role2, role3);
            builder.Entity<Permission>().HasData(permission1, permission2, permission3, permission4, permission5);
            builder.Entity<Module>().HasData(module1);

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
        }
    }
}
