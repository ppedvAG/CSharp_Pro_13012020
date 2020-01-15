using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HalloWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hersteller = table.Column<string>(nullable: true),
                    Vertieb = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    Titel = table.Column<string>(nullable: true),
                    Preis = table.Column<decimal>(nullable: false),
                    Veröffentlicht = table.Column<DateTime>(nullable: false),
                    Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
