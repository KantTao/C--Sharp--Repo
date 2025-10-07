using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintBrand_PaintProdut_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintProduct_PaintBrandTable_PaintBrandId",
                table: "PaintProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintProduct",
                table: "PaintProduct");

            migrationBuilder.RenameTable(
                name: "PaintProduct",
                newName: "PaintProductTable");

            migrationBuilder.RenameIndex(
                name: "IX_PaintProduct_PaintBrandId",
                table: "PaintProductTable",
                newName: "IX_PaintProductTable_PaintBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintProductTable",
                table: "PaintProductTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintProductTable_PaintBrandTable_PaintBrandId",
                table: "PaintProductTable",
                column: "PaintBrandId",
                principalTable: "PaintBrandTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintProductTable_PaintBrandTable_PaintBrandId",
                table: "PaintProductTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintProductTable",
                table: "PaintProductTable");

            migrationBuilder.RenameTable(
                name: "PaintProductTable",
                newName: "PaintProduct");

            migrationBuilder.RenameIndex(
                name: "IX_PaintProductTable_PaintBrandId",
                table: "PaintProduct",
                newName: "IX_PaintProduct_PaintBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintProduct",
                table: "PaintProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintProduct_PaintBrandTable_PaintBrandId",
                table: "PaintProduct",
                column: "PaintBrandId",
                principalTable: "PaintBrandTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
