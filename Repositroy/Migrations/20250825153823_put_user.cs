using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class put_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666445L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666446L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666447L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666448L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666449L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666450L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666451L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666452L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666453L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914008443666454L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1914008443666442L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1914008443666443L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1914008443666444L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914008443666437L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914008443666438L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914008443666439L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914008443666440L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914008443666441L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1914008443666434L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1914008443666435L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1914008443666436L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1914008443666432L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1914008443666433L);

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "User",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url" },
                values: new object[,]
                {
                    { 1914066240733189L, "", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8189), "", "文章添加", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8190), "api/article/add" },
                    { 1914066240733190L, "", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8193), "", "文章删除", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8194), "api/article/delete" },
                    { 1914066240733191L, "", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8195), "", "文章修改", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8196), "api/article/update" },
                    { 1914066240733192L, "", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8197), "", "文章详情", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8197), "api/article/GetDetail" },
                    { 1914066240733193L, "", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8198), "", "文章列表", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8199), "api/article/Get" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1914066240733186L, new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8181), "", "管理员", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8182) },
                    { 1914066240733187L, new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8185), "", "普通用户", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8186) },
                    { 1914066240733188L, new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8187), "", "游客", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8188) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { 1914066240733184L, "shanyue", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8143), "mountainmono@gmail.com", "dk", "山月", "123456", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8155) },
                    { 1914066240733185L, "xuecun", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8161), "1906525910@gmail.com", "kd", "雪村", "123456", new DateTime(2025, 8, 25, 23, 38, 22, 961, DateTimeKind.Local).AddTicks(8162) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1914066240733197L, 1914066240733189L, 1914066240733186L },
                    { 1914066240733198L, 1914066240733190L, 1914066240733186L },
                    { 1914066240733199L, 1914066240733191L, 1914066240733186L },
                    { 1914066240733200L, 1914066240733192L, 1914066240733186L },
                    { 1914066240733201L, 1914066240733193L, 1914066240733186L },
                    { 1914066240733202L, 1914066240733189L, 1914066240733187L },
                    { 1914066240733203L, 1914066240733190L, 1914066240733187L },
                    { 1914066240733204L, 1914066240733192L, 1914066240733187L },
                    { 1914066240733205L, 1914066240733193L, 1914066240733187L },
                    { 1914066240733206L, 1914066240733192L, 1914066240733188L }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1914066240733194L, 1914066240733186L, 1914066240733184L },
                    { 1914066240733195L, 1914066240733187L, 1914066240733185L },
                    { 1914066240733196L, 1914066240733187L, 1914066240733184L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733197L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733198L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733199L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733200L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733201L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733202L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733203L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733204L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733205L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1914066240733206L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1914066240733194L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1914066240733195L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1914066240733196L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914066240733189L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914066240733190L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914066240733191L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914066240733192L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1914066240733193L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1914066240733186L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1914066240733187L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1914066240733188L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1914066240733184L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1914066240733185L);

            migrationBuilder.DropColumn(
                name: "Account",
                table: "User");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url" },
                values: new object[,]
                {
                    { 1914008443666437L, "", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(97), "", "文章添加", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(98), "api/article/add" },
                    { 1914008443666438L, "", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(102), "", "文章删除", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(102), "api/article/delete" },
                    { 1914008443666439L, "", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(103), "", "文章修改", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(104), "api/article/update" },
                    { 1914008443666440L, "", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(105), "", "文章详情", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(105), "api/article/GetDetail" },
                    { 1914008443666441L, "", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(106), "", "文章列表", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(106), "api/article/Get" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1914008443666434L, new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(91), "", "管理员", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(91) },
                    { 1914008443666435L, new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(95), "", "普通用户", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(95) },
                    { 1914008443666436L, new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(96), "", "游客", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(96) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateTime", "Email", "Name", "NickName", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { 1914008443666432L, new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(68), "mountainmono@gmail.com", "dk", "shanyue", "123456", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(79) },
                    { 1914008443666433L, new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(89), "1906525910@gmail.com", "kd", "xuecun", "123456", new DateTime(2025, 8, 25, 19, 43, 12, 349, DateTimeKind.Local).AddTicks(90) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1914008443666445L, 1914008443666437L, 1914008443666434L },
                    { 1914008443666446L, 1914008443666438L, 1914008443666434L },
                    { 1914008443666447L, 1914008443666439L, 1914008443666434L },
                    { 1914008443666448L, 1914008443666440L, 1914008443666434L },
                    { 1914008443666449L, 1914008443666441L, 1914008443666434L },
                    { 1914008443666450L, 1914008443666437L, 1914008443666435L },
                    { 1914008443666451L, 1914008443666438L, 1914008443666435L },
                    { 1914008443666452L, 1914008443666440L, 1914008443666435L },
                    { 1914008443666453L, 1914008443666441L, 1914008443666435L },
                    { 1914008443666454L, 1914008443666440L, 1914008443666436L }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1914008443666442L, 1914008443666434L, 1914008443666432L },
                    { 1914008443666443L, 1914008443666435L, 1914008443666433L },
                    { 1914008443666444L, 1914008443666435L, 1914008443666432L }
                });
        }
    }
}
