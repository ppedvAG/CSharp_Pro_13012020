using Microsoft.EntityFrameworkCore.Migrations;

namespace HalloWeb.Migrations
{
    public partial class Verison2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alter",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alter",
                table: "Games");
        }
    }
}
