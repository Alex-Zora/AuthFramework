using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class update_article : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            //先删除主键约束、修改完之后再添加主键约束
            #region
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Articles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");
            #endregion

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "Type",
                table: "Articles",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "Name", "UpdateDate", "Url", "type" },
                values: new object[,]
                {
                    { 1915515891732485L, "", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2727), "", "文章添加", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2727), "/api/article/add", 0 },
                    { 1915515891732486L, "", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2732), "", "文章删除", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2733), "/api/article/delete", 0 },
                    { 1915515891732487L, "", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2734), "", "文章修改", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2734), "/api/article/update", 0 },
                    { 1915515891732488L, "", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2735), "", "文章详情", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2735), "/api/article/GetDetail", 0 },
                    { 1915515891732489L, "", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2736), "", "文章列表", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2737), "/api/article/Get", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1915515891732482L, new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2717), "", "管理员", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2717) },
                    { 1915515891732483L, new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2723), "", "普通用户", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2724) },
                    { 1915515891732484L, new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2725), "", "游客", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2726) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreateTime", "Email", "Name", "NickName", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { 1915515891732480L, "shanyue", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2695), "mountainmono@gmail.com", "dk", "山月", "123456", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2709) },
                    { 1915515891732481L, "xuecun", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2716), "1906525910@gmail.com", "kd", "雪村", "123456", new DateTime(2025, 8, 30, 1, 57, 1, 662, DateTimeKind.Local).AddTicks(2716) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissionTable",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1915515891732493L, 1915515891732485L, 1915515891732482L },
                    { 1915515891732494L, 1915515891732486L, 1915515891732482L },
                    { 1915515891732495L, 1915515891732487L, 1915515891732482L },
                    { 1915515891732496L, 1915515891732488L, 1915515891732482L },
                    { 1915515891732497L, 1915515891732489L, 1915515891732482L },
                    { 1915515891732498L, 1915515891732485L, 1915515891732483L },
                    { 1915515891732499L, 1915515891732486L, 1915515891732483L },
                    { 1915515891732500L, 1915515891732488L, 1915515891732483L },
                    { 1915515891732501L, 1915515891732489L, 1915515891732483L },
                    { 1915515891732502L, 1915515891732488L, 1915515891732484L }
                });

            migrationBuilder.InsertData(
                table: "UserRoleTable",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1915515891732490L, 1915515891732482L, 1915515891732480L },
                    { 1915515891732491L, 1915515891732483L, 1915515891732481L },
                    { 1915515891732492L, 1915515891732483L, 1915515891732480L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732493L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732494L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732495L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732496L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732497L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732498L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732499L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732500L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732501L);

            migrationBuilder.DeleteData(
                table: "RolePermissionTable",
                keyColumn: "Id",
                keyValue: 1915515891732502L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915515891732490L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915515891732491L);

            migrationBuilder.DeleteData(
                table: "UserRoleTable",
                keyColumn: "Id",
                keyValue: 1915515891732492L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915515891732485L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915515891732486L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915515891732487L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915515891732488L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1915515891732489L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915515891732482L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915515891732483L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1915515891732484L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915515891732480L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1915515891732481L);

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            // 回滚操作，反过来
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Articles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Articles",
                nullable: false);

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
    }
}
