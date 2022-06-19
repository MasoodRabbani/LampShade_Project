using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EfCore.Migrations
{
    public partial class Edit_OprationPropertis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "InventoryOperation",
                newName: "OperatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "InventoryOperation",
                newName: "OperationId");
        }
    }
}
