using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class update_usertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "User",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.CreateIndex(
                name: "IX_User_Account",
                table: "User",
                column: "Account",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Account",
                table: "User");

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

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
