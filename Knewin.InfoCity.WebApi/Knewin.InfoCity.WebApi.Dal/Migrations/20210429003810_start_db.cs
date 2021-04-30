using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Knewin.InfoCity.WebApi.Dal.Migrations
{
    public partial class start_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityBorder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityBorderAId = table.Column<int>(type: "int", nullable: false),
                    CityBorderBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBorder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityBorder_City_CityBorderAId",
                        column: x => x.CityBorderAId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityBorder_City_CityBorderBId",
                        column: x => x.CityBorderBId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityBorder_CityBorderAId",
                table: "CityBorder",
                column: "CityBorderAId");

            migrationBuilder.CreateIndex(
                name: "IX_CityBorder_CityBorderBId",
                table: "CityBorder",
                column: "CityBorderBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityBorder");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
