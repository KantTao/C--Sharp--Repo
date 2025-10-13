using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintSystemAPIVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class ModifyyUserTableName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTable_userTable_UserId",
                table: "OrderTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userTable",
                table: "userTable");

            migrationBuilder.RenameTable(
                name: "userTable",
                newName: "UserTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTable",
                table: "UserTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTable_UserTable_UserId",
                table: "OrderTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTable_UserTable_UserId",
                table: "OrderTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTable",
                table: "UserTable");

            migrationBuilder.RenameTable(
                name: "UserTable",
                newName: "userTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTable",
                table: "userTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTable_userTable_UserId",
                table: "OrderTable",
                column: "UserId",
                principalTable: "userTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
