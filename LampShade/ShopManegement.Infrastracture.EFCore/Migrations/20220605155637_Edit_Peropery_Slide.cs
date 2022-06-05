using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManegement.Infrastracture.EFCore.Migrations
{
    public partial class Edit_Peropery_Slide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Slide",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Slide");
        }
    }
}
