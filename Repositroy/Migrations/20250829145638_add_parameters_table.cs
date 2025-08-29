using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class add_parameters_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Permission",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Basicparameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basicparameters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url", "type" },
                values: new object[,]
                {
                    { 1915471557648389L, "", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1429), "", "文章添加", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1429), "/api/article/add", 0 },
                    { 1915471557648390L, "", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1432), "", "文章删除", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1432), "/api/article/delete", 0 },
                    { 1915471557648391L, "", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1433), "", "文章修改", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1433), "/api/article/update", 0 },
                    { 1915471557648392L, "", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1434), "", "文章详情", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1435), "/api/article/GetDetail", 0 },
                    { 1915471557648393L, "", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1436), "", "文章列表", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1436), "/api/article/Get", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1915471557648386L, new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1420), "", "管理员", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1420) },
                    { 1915471557648387L, new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1425), "", "普通用户", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1426) },
                    { 1915471557648388L, new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1427), "", "游客", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1428) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { 1915471557648384L, "shanyue", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1401), "mountainmono@gmail.com", "dk", "山月", "123456", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1413) },
                    { 1915471557648385L, "xuecun", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1418), "1906525910@gmail.com", "kd", "雪村", "123456", new DateTime(2025, 8, 29, 22, 56, 37, 911, DateTimeKind.Local).AddTicks(1419) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1915471557648397L, 1915471557648389L, 1915471557648386L },
                    { 1915471557648398L, 1915471557648390L, 1915471557648386L },
                    { 1915471557648399L, 1915471557648391L, 1915471557648386L },
                    { 1915471557648400L, 1915471557648392L, 1915471557648386L },
                    { 1915471557648401L, 1915471557648393L, 1915471557648386L },
                    { 1915471557648402L, 1915471557648389L, 1915471557648387L },
                    { 1915471557648403L, 1915471557648390L, 1915471557648387L },
                    { 1915471557648404L, 1915471557648392L, 1915471557648387L },
                    { 1915471557648405L, 1915471557648393L, 1915471557648387L },
                    { 1915471557648406L, 1915471557648392L, 1915471557648388L }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1915471557648394L, 1915471557648386L, 1915471557648384L },
                    { 1915471557648395L, 1915471557648387L, 1915471557648385L },
                    { 1915471557648396L, 1915471557648387L, 1915471557648384L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basicparameters");

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648397L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648398L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648399L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648400L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648401L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648402L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648403L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648404L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648405L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915471557648406L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915471557648394L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915471557648395L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915471557648396L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915471557648389L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915471557648390L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915471557648391L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915471557648392L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915471557648393L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915471557648386L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915471557648387L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915471557648388L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915471557648384L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915471557648385L);

            migrationBuilder.DropColumn(
                name: "type",
                table: "Permission");

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
    }
}
