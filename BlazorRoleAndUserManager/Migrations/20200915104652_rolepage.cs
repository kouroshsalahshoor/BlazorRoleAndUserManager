using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRoleAndUserManager.Migrations
{
    public partial class rolepage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RolePages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<string>(nullable: true),
                    AppRoleId = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false),
                    AppPageId = table.Column<int>(nullable: true),
                    CanCreate = table.Column<bool>(nullable: false),
                    CanRead = table.Column<bool>(nullable: false),
                    CanUpdate = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePages_AppPages_AppPageId",
                        column: x => x.AppPageId,
                        principalTable: "AppPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePages_AspNetRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePages_AppPageId",
                table: "RolePages",
                column: "AppPageId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePages_AppRoleId",
                table: "RolePages",
                column: "AppRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetRoles");
        }
    }
}
