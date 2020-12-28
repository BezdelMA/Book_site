using Microsoft.EntityFrameworkCore.Migrations;

namespace book_site.Migrations
{
    public partial class AddAllPriceInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllPrice",
                table: "Orders");
        }
    }
}
