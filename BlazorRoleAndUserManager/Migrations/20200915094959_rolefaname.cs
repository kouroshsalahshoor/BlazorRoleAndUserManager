using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRoleAndUserManager.Migrations
{
    public partial class rolefaname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaName",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaName",
                table: "AspNetRoles");
        }
    }
}
