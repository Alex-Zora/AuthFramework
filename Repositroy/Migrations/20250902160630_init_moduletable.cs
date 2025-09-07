using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class init_moduletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionTable_Permission_PermissionId",
                table: "RolePermissionTable");

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

            migrationBuilder.AlterColumn<long>(
                name: "PermissionId",
                table: "RolePermissionTable",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ModuleId",
                table: "RolePermissionTable",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "testFiles",
                table: "RolePermissionTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsButton = table.Column<bool>(type: "bit", nullable: false),
                    IsHide = table.Column<bool>(type: "bit", nullable: true),
                    IskeepAlive = table.Column<bool>(type: "bit", nullable: true),
                    Func = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderSort = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IconNew = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<long>(type: "bigint", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Pid = table.Column<long>(type: "bigint", nullable: false),
                    Mid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "CreateBy", "CreateId", "CreateTime", "Description", "Enabled", "Func", "Icon", "IconNew", "IsButton", "IsDeleted", "IsHide", "IskeepAlive", "Mid", "ModifyBy", "ModifyId", "ModifyTime", "Name", "OrderSort", "Pid" },
                values: new object[] { 0L, "", "", null, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8312), "", false, "", "", "", false, null, false, false, 0L, "", null, new DateTime(2025, 9, 3, 0, 6, 30, 115, DateTimeKind.Local).AddTicks(8312), null, 0, 0L });

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

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionTable_ModuleId",
                table: "RolePermissionTable",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionTable_Modules_ModuleId",
                table: "RolePermissionTable",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionTable_Permission_PermissionId",
                table: "RolePermissionTable",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionTable_Modules_ModuleId",
                table: "RolePermissionTable");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionTable_Permission_PermissionId",
                table: "RolePermissionTable");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionTable_ModuleId",
                table: "RolePermissionTable");

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

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "RolePermissionTable");

            migrationBuilder.DropColumn(
                name: "testFiles",
                table: "RolePermissionTable");

            migrationBuilder.AlterColumn<long>(
                name: "PermissionId",
                table: "RolePermissionTable",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionTable_Permission_PermissionId",
                table: "RolePermissionTable",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
