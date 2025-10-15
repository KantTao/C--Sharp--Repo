using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintProduct_Order_Many_to_Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPaintProduct");

            migrationBuilder.AddColumn<int>(
                name: "PaintProductId",
                table: "OrderTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderPaintProductTable",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaintProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaintProductTable", x => new { x.OrderId, x.PaintProductId });
                    table.ForeignKey(
                        name: "FK_OrderPaintProductTable_OrderTable_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPaintProductTable_PaintProductTable_PaintProductId",
                        column: x => x.PaintProductId,
                        principalTable: "PaintProductTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_PaintProductId",
                table: "OrderTable",
                column: "PaintProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaintProductTable_PaintProductId",
                table: "OrderPaintProductTable",
                column: "PaintProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTable_PaintProductTable_PaintProductId",
                table: "OrderTable",
                column: "PaintProductId",
                principalTable: "PaintProductTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTable_PaintProductTable_PaintProductId",
                table: "OrderTable");

            migrationBuilder.DropTable(
                name: "OrderPaintProductTable");

            migrationBuilder.DropIndex(
                name: "IX_OrderTable_PaintProductId",
                table: "OrderTable");

            migrationBuilder.DropColumn(
                name: "PaintProductId",
                table: "OrderTable");

            migrationBuilder.CreateTable(
                name: "OrderPaintProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    PaintProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaintProduct", x => new { x.OrdersId, x.PaintProductsId });
                    table.ForeignKey(
                        name: "FK_OrderPaintProduct_OrderTable_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "OrderTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPaintProduct_PaintProductTable_PaintProductsId",
                        column: x => x.PaintProductsId,
                        principalTable: "PaintProductTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaintProduct_PaintProductsId",
                table: "OrderPaintProduct",
                column: "PaintProductsId");
        }
    }
}
