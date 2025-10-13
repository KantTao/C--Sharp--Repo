using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintSeries_PaintProduct_1_to_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintSeries_PaintBrandTable_PaintBrandId",
                table: "PaintSeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintSeries",
                table: "PaintSeries");

            migrationBuilder.RenameTable(
                name: "PaintSeries",
                newName: "PaintSeriesTable");

            migrationBuilder.RenameIndex(
                name: "IX_PaintSeries_PaintBrandId",
                table: "PaintSeriesTable",
                newName: "IX_PaintSeriesTable_PaintBrandId");

            migrationBuilder.AddColumn<int>(
                name: "PaintSeriesId",
                table: "PaintProductTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintSeriesTable",
                table: "PaintSeriesTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PaintProductTable_PaintSeriesId",
                table: "PaintProductTable",
                column: "PaintSeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintProductTable_PaintSeriesTable_PaintSeriesId",
                table: "PaintProductTable",
                column: "PaintSeriesId",
                principalTable: "PaintSeriesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintSeriesTable_PaintBrandTable_PaintBrandId",
                table: "PaintSeriesTable",
                column: "PaintBrandId",
                principalTable: "PaintBrandTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintProductTable_PaintSeriesTable_PaintSeriesId",
                table: "PaintProductTable");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintSeriesTable_PaintBrandTable_PaintBrandId",
                table: "PaintSeriesTable");

            migrationBuilder.DropIndex(
                name: "IX_PaintProductTable_PaintSeriesId",
                table: "PaintProductTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintSeriesTable",
                table: "PaintSeriesTable");

            migrationBuilder.DropColumn(
                name: "PaintSeriesId",
                table: "PaintProductTable");

            migrationBuilder.RenameTable(
                name: "PaintSeriesTable",
                newName: "PaintSeries");

            migrationBuilder.RenameIndex(
                name: "IX_PaintSeriesTable_PaintBrandId",
                table: "PaintSeries",
                newName: "IX_PaintSeries_PaintBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintSeries",
                table: "PaintSeries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintSeries_PaintBrandTable_PaintBrandId",
                table: "PaintSeries",
                column: "PaintBrandId",
                principalTable: "PaintBrandTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
