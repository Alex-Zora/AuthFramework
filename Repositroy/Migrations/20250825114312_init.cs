using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShanYue.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    DateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.DateId);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionTable_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionTable_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleTable_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleTable_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionTable_PermissionId",
                table: "RolePermissionTable",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionTable_RoleId",
                table: "RolePermissionTable",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleTable_RoleId",
                table: "UserRoleTable",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleTable_UserId",
                table: "UserRoleTable",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "RolePermissionTable");

            migrationBuilder.DropTable(
                name: "UserRoleTable");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
