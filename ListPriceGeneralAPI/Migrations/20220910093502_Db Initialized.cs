using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListPriceGeneralAPI.Migrations
{
    public partial class DbInitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
