using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class PaintCategories_PaintProducts_1_to_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaintCategoryId",
                table: "PaintProductTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaintCategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintCategoryTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaintProductTable_PaintCategoryId",
                table: "PaintProductTable",
                column: "PaintCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintProductTable_PaintCategoryTable_PaintCategoryId",
                table: "PaintProductTable",
                column: "PaintCategoryId",
                principalTable: "PaintCategoryTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintProductTable_PaintCategoryTable_PaintCategoryId",
                table: "PaintProductTable");

            migrationBuilder.DropTable(
                name: "PaintCategoryTable");

            migrationBuilder.DropIndex(
                name: "IX_PaintProductTable_PaintCategoryId",
                table: "PaintProductTable");

            migrationBuilder.DropColumn(
                name: "PaintCategoryId",
                table: "PaintProductTable");
        }
    }
}
