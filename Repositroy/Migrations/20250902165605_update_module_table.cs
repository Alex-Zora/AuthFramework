using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class update_module_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515981L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515982L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515983L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515984L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515985L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515986L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515987L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515988L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515989L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916904306515990L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1916904306515978L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1916904306515979L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1916904306515980L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916904306515973L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916904306515974L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916904306515975L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916904306515976L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916904306515977L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1916904306515970L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1916904306515971L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1916904306515972L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1916904306515968L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1916904306515969L);

            migrationBuilder.RenameColumn(
                name: "IskeepAlive",
                table: "Modules",
                newName: "IsKeepAlive");

            migrationBuilder.RenameColumn(
                name: "Pid",
                table: "Modules",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "ModifyTime",
                table: "Modules",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "ModifyId",
                table: "Modules",
                newName: "UpdateId");

            migrationBuilder.RenameColumn(
                name: "ModifyBy",
                table: "Modules",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "Mid",
                table: "Modules",
                newName: "ParentId");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 0L,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2418), new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2419) });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url", "type" },
                values: new object[,]
                {
                    { 1916916492496901L, "", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2408), "", "文章添加", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2408), "/api/article/add", 0 },
                    { 1916916492496902L, "", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2413), "", "文章删除", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2413), "/api/article/delete", 0 },
                    { 1916916492496903L, "", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2414), "", "文章修改", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2414), "/api/article/update", 0 },
                    { 1916916492496904L, "", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2415), "", "文章详情", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2415), "/api/article/GetDetail", 0 },
                    { 1916916492496905L, "", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2416), "", "文章列表", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2416), "/api/article/Get", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1916916492496898L, new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2399), "", "管理员", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2399) },
                    { 1916916492496899L, new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2405), "", "普通用户", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2405) },
                    { 1916916492496900L, new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2406), "", "游客", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2407) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "PasswordSalt", "TokenVersion", "UpdateTime" },
                values: new object[,]
                {
                    { 1916916492496896L, "shanyue", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2379), "mountainmono@gmail.com", "dk", "山月", "123456", "", 0, new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2390) },
                    { 1916916492496897L, "xuecun", new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2397), "1906525910@gmail.com", "kd", "雪村", "123456", "", 0, new DateTime(2025, 9, 3, 0, 56, 5, 208, DateTimeKind.Local).AddTicks(2397) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "ModuleId", "PermissionId", "RoleId", "testFiles" },
                values: new object[,]
                {
                    { 1916916492496909L, null, 1916916492496901L, 1916916492496898L, "" },
                    { 1916916492496910L, null, 1916916492496902L, 1916916492496898L, "" },
                    { 1916916492496911L, null, 1916916492496903L, 1916916492496898L, "" },
                    { 1916916492496912L, null, 1916916492496904L, 1916916492496898L, "" },
                    { 1916916492496913L, null, 1916916492496905L, 1916916492496898L, "" },
                    { 1916916492496914L, null, 1916916492496901L, 1916916492496899L, "" },
                    { 1916916492496915L, null, 1916916492496902L, 1916916492496899L, "" },
                    { 1916916492496916L, null, 1916916492496904L, 1916916492496899L, "" },
                    { 1916916492496917L, null, 1916916492496905L, 1916916492496899L, "" },
                    { 1916916492496918L, null, 1916916492496904L, 1916916492496900L, "" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1916916492496906L, 1916916492496898L, 1916916492496896L },
                    { 1916916492496907L, 1916916492496899L, 1916916492496897L },
                    { 1916916492496908L, 1916916492496899L, 1916916492496896L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496909L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496910L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496911L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496912L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496913L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496914L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496915L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496916L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496917L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1916916492496918L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1916916492496906L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1916916492496907L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1916916492496908L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916916492496901L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916916492496902L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916916492496903L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916916492496904L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1916916492496905L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1916916492496898L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1916916492496899L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1916916492496900L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1916916492496896L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1916916492496897L);

            migrationBuilder.RenameColumn(
                name: "IsKeepAlive",
                table: "Modules",
                newName: "IskeepAlive");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Modules",
                newName: "ModifyTime");

            migrationBuilder.RenameColumn(
                name: "UpdateId",
                table: "Modules",
                newName: "ModifyId");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "Modules",
                newName: "ModifyBy");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Modules",
                newName: "Pid");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Modules",
                newName: "Mid");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 0L,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8312), new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8312) });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url", "type" },
                values: new object[,]
                {
                    { 1916904306515973L, "", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8301), "", "文章添加", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8301), "/api/article/add", 0 },
                    { 1916904306515974L, "", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8305), "", "文章删除", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8306), "/api/article/delete", 0 },
                    { 1916904306515975L, "", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8306), "", "文章修改", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8307), "/api/article/update", 0 },
                    { 1916904306515976L, "", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8308), "", "文章详情", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8308), "/api/article/GetDetail", 0 },
                    { 1916904306515977L, "", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8309), "", "文章列表", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8309), "/api/article/Get", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1916904306515970L, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8294), "", "管理员", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8294) },
                    { 1916904306515971L, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8298), "", "普通用户", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8298) },
                    { 1916904306515972L, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8300), "", "游客", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8300) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "PasswordSalt", "TokenVersion", "UpdateTime" },
                values: new object[,]
                {
                    { 1916904306515968L, "shanyue", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8269), "mountainmono@gmail.com", "dk", "山月", "123456", "", 0, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8282) },
                    { 1916904306515969L, "xuecun", new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8292), "1906525910@gmail.com", "kd", "雪村", "123456", "", 0, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8292) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "ModuleId", "PermissionId", "RoleId", "testFiles" },
                values: new object[,]
                {
                    { 1916904306515981L, null, 1916904306515973L, 1916904306515970L, "" },
                    { 1916904306515982L, null, 1916904306515974L, 1916904306515970L, "" },
                    { 1916904306515983L, null, 1916904306515975L, 1916904306515970L, "" },
                    { 1916904306515984L, null, 1916904306515976L, 1916904306515970L, "" },
                    { 1916904306515985L, null, 1916904306515977L, 1916904306515970L, "" },
                    { 1916904306515986L, null, 1916904306515973L, 1916904306515971L, "" },
                    { 1916904306515987L, null, 1916904306515974L, 1916904306515971L, "" },
                    { 1916904306515988L, null, 1916904306515976L, 1916904306515971L, "" },
                    { 1916904306515989L, null, 1916904306515977L, 1916904306515971L, "" },
                    { 1916904306515990L, null, 1916904306515976L, 1916904306515972L, "" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1916904306515978L, 1916904306515970L, 1916904306515968L },
                    { 1916904306515979L, 1916904306515971L, 1916904306515969L },
                    { 1916904306515980L, 1916904306515971L, 1916904306515968L }
                });
        }
    }
}
