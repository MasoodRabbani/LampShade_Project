using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastracture.EfCore.Migrations
{
    public partial class IgnorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Permission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Permission",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
