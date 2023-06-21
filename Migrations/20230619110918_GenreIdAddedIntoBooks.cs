using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.Migrations
{
    public partial class GenreIdAddedIntoBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Books_BooksId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_BooksId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenresId",
                table: "Books",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenresId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_BooksId",
                table: "Genres",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Books_BooksId",
                table: "Genres",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
