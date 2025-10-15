using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintProductsStock_StockTransaction_Many_to_Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTransactionDetail",
                columns: table => new
                {
                    PaintProductsStockId = table.Column<int>(type: "int", nullable: false),
                    StockTransactionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransactionDetail", x => new { x.PaintProductsStockId, x.StockTransactionId });
                    table.ForeignKey(
                        name: "FK_StockTransactionDetail_PaintProductsStockTable_PaintProductsStockId",
                        column: x => x.PaintProductsStockId,
                        principalTable: "PaintProductsStockTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockTransactionDetail_StockTransaction_StockTransactionId",
                        column: x => x.StockTransactionId,
                        principalTable: "StockTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactionDetail_StockTransactionId",
                table: "StockTransactionDetail",
                column: "StockTransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTransactionDetail");
        }
    }
}
