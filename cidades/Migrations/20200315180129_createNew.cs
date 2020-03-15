using Microsoft.EntityFrameworkCore.Migrations;

namespace cidades.Migrations
{
    public partial class createNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    CountryState = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityToCity",
                columns: table => new
                {
                    IdCity = table.Column<int>(nullable: false),
                    IdCityTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityToCity", x => new { x.IdCity, x.IdCityTo });
                    table.ForeignKey(
                        name: "FK_CityToCity_Cities_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityToCity_Cities_IdCityTo",
                        column: x => x.IdCityTo,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_CountryState",
                table: "Cities",
                columns: new[] { "Name", "CountryState" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityToCity_IdCityTo",
                table: "CityToCity",
                column: "IdCityTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityToCity");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
