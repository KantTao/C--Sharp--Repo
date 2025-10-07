using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintProduct_PaintProductStock_1_to_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPaintProduct_OrderTable_OrderId",
                table: "OrderPaintProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPaintProduct_PaintProductTable_PaintProductId",
                table: "OrderPaintProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPaintProduct",
                table: "OrderPaintProduct");

            migrationBuilder.RenameTable(
                name: "OrderPaintProduct",
                newName: "OrderPaintProductTable");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPaintProduct_PaintProductId",
                table: "OrderPaintProductTable",
                newName: "IX_OrderPaintProductTable_PaintProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPaintProductTable",
                table: "OrderPaintProductTable",
                columns: new[] { "OrderId", "PaintProductId" });

            migrationBuilder.CreateTable(
                name: "PaintProductsStockTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaintProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintProductsStockTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaintProductsStockTable_PaintProductTable_PaintProductId",
                        column: x => x.PaintProductId,
                        principalTable: "PaintProductTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaintProductsStockTable_PaintProductId",
                table: "PaintProductsStockTable",
                column: "PaintProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPaintProductTable_OrderTable_OrderId",
                table: "OrderPaintProductTable",
                column: "OrderId",
                principalTable: "OrderTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPaintProductTable_PaintProductTable_PaintProductId",
                table: "OrderPaintProductTable",
                column: "PaintProductId",
                principalTable: "PaintProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPaintProductTable_OrderTable_OrderId",
                table: "OrderPaintProductTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPaintProductTable_PaintProductTable_PaintProductId",
                table: "OrderPaintProductTable");

            migrationBuilder.DropTable(
                name: "PaintProductsStockTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPaintProductTable",
                table: "OrderPaintProductTable");

            migrationBuilder.RenameTable(
                name: "OrderPaintProductTable",
                newName: "OrderPaintProduct");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPaintProductTable_PaintProductId",
                table: "OrderPaintProduct",
                newName: "IX_OrderPaintProduct_PaintProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPaintProduct",
                table: "OrderPaintProduct",
                columns: new[] { "OrderId", "PaintProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPaintProduct_OrderTable_OrderId",
                table: "OrderPaintProduct",
                column: "OrderId",
                principalTable: "OrderTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPaintProduct_PaintProductTable_PaintProductId",
                table: "OrderPaintProduct",
                column: "PaintProductId",
                principalTable: "PaintProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
