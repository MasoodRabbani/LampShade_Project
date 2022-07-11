using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogManagement.Infracture.EfCore.Migrations
{
    public partial class EditCoulmn_Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MrtaDescription",
                table: "Article",
                newName: "MetaDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaDescription",
                table: "Article",
                newName: "MrtaDescription");
        }
    }
}
