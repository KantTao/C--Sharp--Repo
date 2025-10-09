using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublisher_Books_BooksId",
                table: "BookPublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "BookTable");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "BookTable",
                newName: "IX_BookTable_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTable",
                table: "BookTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublisher_BookTable_BooksId",
                table: "BookPublisher",
                column: "BooksId",
                principalTable: "BookTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTable_Authors_AuthorId",
                table: "BookTable",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublisher_BookTable_BooksId",
                table: "BookPublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTable_Authors_AuthorId",
                table: "BookTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTable",
                table: "BookTable");

            migrationBuilder.RenameTable(
                name: "BookTable",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_BookTable_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublisher_Books_BooksId",
                table: "BookPublisher",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
