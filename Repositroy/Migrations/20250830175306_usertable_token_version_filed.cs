using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class usertable_token_version_filed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140365L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140366L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140367L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140368L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140369L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140370L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140371L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140372L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140373L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915831863140374L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915831863140362L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915831863140363L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915831863140364L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915831863140357L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915831863140358L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915831863140359L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915831863140360L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915831863140361L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915831863140354L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915831863140355L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915831863140356L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915831863140352L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915831863140353L);

            migrationBuilder.AddColumn<int>(
                name: "TokenVersion",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url", "type" },
                values: new object[,]
                {
                    { 1915868823474181L, "", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4501), "", "文章添加", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4502), "/api/article/add", 0 },
                    { 1915868823474182L, "", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4506), "", "文章删除", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4506), "/api/article/delete", 0 },
                    { 1915868823474183L, "", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4508), "", "文章修改", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4508), "/api/article/update", 0 },
                    { 1915868823474184L, "", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4509), "", "文章详情", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4509), "/api/article/GetDetail", 0 },
                    { 1915868823474185L, "", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4510), "", "文章列表", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4511), "/api/article/Get", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1915868823474178L, new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4494), "", "管理员", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4495) },
                    { 1915868823474179L, new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4499), "", "普通用户", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4499) },
                    { 1915868823474180L, new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4500), "", "游客", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4500) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "PasswordSalt", "TokenVersion", "UpdateTime" },
                values: new object[,]
                {
                    { 1915868823474176L, "shanyue", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4474), "mountainmono@gmail.com", "dk", "山月", "123456", "", 0, new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4486) },
                    { 1915868823474177L, "xuecun", new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4492), "1906525910@gmail.com", "kd", "雪村", "123456", "", 0, new DateTime(2025, 8, 31, 1, 53, 6, 638, DateTimeKind.Local).AddTicks(4493) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1915868823474189L, 1915868823474181L, 1915868823474178L },
                    { 1915868823474190L, 1915868823474182L, 1915868823474178L },
                    { 1915868823474191L, 1915868823474183L, 1915868823474178L },
                    { 1915868823474192L, 1915868823474184L, 1915868823474178L },
                    { 1915868823474193L, 1915868823474185L, 1915868823474178L },
                    { 1915868823474194L, 1915868823474181L, 1915868823474179L },
                    { 1915868823474195L, 1915868823474182L, 1915868823474179L },
                    { 1915868823474196L, 1915868823474184L, 1915868823474179L },
                    { 1915868823474197L, 1915868823474185L, 1915868823474179L },
                    { 1915868823474198L, 1915868823474184L, 1915868823474180L }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1915868823474186L, 1915868823474178L, 1915868823474176L },
                    { 1915868823474187L, 1915868823474179L, 1915868823474177L },
                    { 1915868823474188L, 1915868823474179L, 1915868823474176L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474189L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474190L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474191L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474192L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474193L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474194L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474195L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474196L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474197L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915868823474198L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915868823474186L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915868823474187L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915868823474188L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915868823474181L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915868823474182L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915868823474183L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915868823474184L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915868823474185L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915868823474178L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915868823474179L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915868823474180L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915868823474176L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915868823474177L);

            migrationBuilder.DropColumn(
                name: "TokenVersion",
                table: "User");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url", "type" },
                values: new object[,]
                {
                    { 1915831863140357L, "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9561), "", "文章添加", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9561), "/api/article/add", 0 },
                    { 1915831863140358L, "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9570), "", "文章删除", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9570), "/api/article/delete", 0 },
                    { 1915831863140359L, "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9571), "", "文章修改", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9572), "/api/article/update", 0 },
                    { 1915831863140360L, "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9573), "", "文章详情", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9573), "/api/article/GetDetail", 0 },
                    { 1915831863140361L, "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9574), "", "文章列表", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9574), "/api/article/Get", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1915831863140354L, new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9553), "", "管理员", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9554) },
                    { 1915831863140355L, new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9558), "", "普通用户", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9558) },
                    { 1915831863140356L, new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9559), "", "游客", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9560) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "PasswordSalt", "UpdateTime" },
                values: new object[,]
                {
                    { 1915831863140352L, "shanyue", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9532), "mountainmono@gmail.com", "dk", "山月", "123456", "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9544) },
                    { 1915831863140353L, "xuecun", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9551), "1906525910@gmail.com", "kd", "雪村", "123456", "", new DateTime(2025, 8, 30, 23, 22, 43, 119, DateTimeKind.Local).AddTicks(9551) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1915831863140365L, 1915831863140357L, 1915831863140354L },
                    { 1915831863140366L, 1915831863140358L, 1915831863140354L },
                    { 1915831863140367L, 1915831863140359L, 1915831863140354L },
                    { 1915831863140368L, 1915831863140360L, 1915831863140354L },
                    { 1915831863140369L, 1915831863140361L, 1915831863140354L },
                    { 1915831863140370L, 1915831863140357L, 1915831863140355L },
                    { 1915831863140371L, 1915831863140358L, 1915831863140355L },
                    { 1915831863140372L, 1915831863140360L, 1915831863140355L },
                    { 1915831863140373L, 1915831863140361L, 1915831863140355L },
                    { 1915831863140374L, 1915831863140360L, 1915831863140356L }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1915831863140362L, 1915831863140354L, 1915831863140352L },
                    { 1915831863140363L, 1915831863140355L, 1915831863140353L },
                    { 1915831863140364L, 1915831863140355L, 1915831863140352L }
                });
        }
    }
}
