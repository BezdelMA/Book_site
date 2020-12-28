using Microsoft.EntityFrameworkCore.Migrations;

namespace book_site.Migrations
{
    public partial class AddNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedNameGenre",
                table: "Genres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedNameBook",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedNameAuthor",
                table: "Authors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedNameGenre",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "NormalizedNameBook",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NormalizedNameAuthor",
                table: "Authors");
        }
    }
}
