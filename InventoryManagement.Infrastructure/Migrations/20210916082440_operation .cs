using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Migrations
{
    public partial class operation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operations_inventory_InventoryId",
                table: "operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operations",
                table: "operations");

            migrationBuilder.RenameTable(
                name: "operations",
                newName: "inventoryOperations");

            migrationBuilder.RenameIndex(
                name: "IX_operations_InventoryId",
                table: "inventoryOperations",
                newName: "IX_inventoryOperations_InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventoryOperations",
                table: "inventoryOperations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventoryOperations_inventory_InventoryId",
                table: "inventoryOperations",
                column: "InventoryId",
                principalTable: "inventory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventoryOperations_inventory_InventoryId",
                table: "inventoryOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventoryOperations",
                table: "inventoryOperations");

            migrationBuilder.RenameTable(
                name: "inventoryOperations",
                newName: "operations");

            migrationBuilder.RenameIndex(
                name: "IX_inventoryOperations_InventoryId",
                table: "operations",
                newName: "IX_operations_InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operations",
                table: "operations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_operations_inventory_InventoryId",
                table: "operations",
                column: "InventoryId",
                principalTable: "inventory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
