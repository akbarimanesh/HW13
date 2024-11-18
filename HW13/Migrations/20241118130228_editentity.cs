using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW13.Migrations
{
    /// <inheritdoc />
    public partial class editentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_users_UserId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "borrowlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_borrowlists_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_borrowlists_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_borrowlists_BookId",
                table: "borrowlists",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_borrowlists_UserId",
                table: "borrowlists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_users_UserId",
                table: "books",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_users_UserId",
                table: "books");

            migrationBuilder.DropTable(
                name: "borrowlists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_books_users_UserId",
                table: "books",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
