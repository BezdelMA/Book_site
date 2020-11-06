using Microsoft.EntityFrameworkCore.Migrations;

namespace book_site.Migrations
{
    public partial class Basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublishingHouse",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Counter = table.Column<int>(nullable: false),
                    BasketBookId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBaskets_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBaskets_BookId",
                table: "BookBaskets",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBaskets");

            migrationBuilder.DropColumn(
                name: "PublishingHouse",
                table: "Books");
        }
    }
}
