using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTransationTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_OrderTable_ReferenceOrderId",
                table: "StockTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_PaintProductTable_PaintProductId",
                table: "StockTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactionDetail_StockTransaction_StockTransactionId",
                table: "StockTransactionDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransaction",
                table: "StockTransaction");

            migrationBuilder.RenameTable(
                name: "StockTransaction",
                newName: "StockTransactionTable");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransaction_ReferenceOrderId",
                table: "StockTransactionTable",
                newName: "IX_StockTransactionTable_ReferenceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransaction_PaintProductId",
                table: "StockTransactionTable",
                newName: "IX_StockTransactionTable_PaintProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransactionTable",
                table: "StockTransactionTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactionDetail_StockTransactionTable_StockTransactionId",
                table: "StockTransactionDetail",
                column: "StockTransactionId",
                principalTable: "StockTransactionTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactionTable_OrderTable_ReferenceOrderId",
                table: "StockTransactionTable",
                column: "ReferenceOrderId",
                principalTable: "OrderTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactionTable_PaintProductTable_PaintProductId",
                table: "StockTransactionTable",
                column: "PaintProductId",
                principalTable: "PaintProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactionDetail_StockTransactionTable_StockTransactionId",
                table: "StockTransactionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactionTable_OrderTable_ReferenceOrderId",
                table: "StockTransactionTable");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactionTable_PaintProductTable_PaintProductId",
                table: "StockTransactionTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransactionTable",
                table: "StockTransactionTable");

            migrationBuilder.RenameTable(
                name: "StockTransactionTable",
                newName: "StockTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactionTable_ReferenceOrderId",
                table: "StockTransaction",
                newName: "IX_StockTransaction_ReferenceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactionTable_PaintProductId",
                table: "StockTransaction",
                newName: "IX_StockTransaction_PaintProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransaction",
                table: "StockTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_OrderTable_ReferenceOrderId",
                table: "StockTransaction",
                column: "ReferenceOrderId",
                principalTable: "OrderTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_PaintProductTable_PaintProductId",
                table: "StockTransaction",
                column: "PaintProductId",
                principalTable: "PaintProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactionDetail_StockTransaction_StockTransactionId",
                table: "StockTransactionDetail",
                column: "StockTransactionId",
                principalTable: "StockTransaction",
                principalColumn: "Id");
        }
    }
}
