using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintProduct_StockTransactions_1_to_Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaintProductId",
                table: "StockTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransaction_PaintProductId",
                table: "StockTransaction",
                column: "PaintProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_PaintProductTable_PaintProductId",
                table: "StockTransaction",
                column: "PaintProductId",
                principalTable: "PaintProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_PaintProductTable_PaintProductId",
                table: "StockTransaction");

            migrationBuilder.DropIndex(
                name: "IX_StockTransaction_PaintProductId",
                table: "StockTransaction");

            migrationBuilder.DropColumn(
                name: "PaintProductId",
                table: "StockTransaction");
        }
    }
}
