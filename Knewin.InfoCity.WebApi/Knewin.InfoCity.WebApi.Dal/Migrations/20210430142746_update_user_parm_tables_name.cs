using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Knewin.InfoCity.WebApi.Dal.Migrations
{
    public partial class update_user_parm_tables_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityBorder_City_CityBorderAId",
                table: "CityBorder");

            migrationBuilder.DropForeignKey(
                name: "FK_CityBorder_City_CityBorderBId",
                table: "CityBorder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityBorder",
                table: "CityBorder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "City");

            migrationBuilder.RenameTable(
                name: "CityBorder",
                newName: "CitiesBorder");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_CityBorder_CityBorderBId",
                table: "CitiesBorder",
                newName: "IX_CitiesBorder_CityBorderBId");

            migrationBuilder.RenameIndex(
                name: "IX_CityBorder_CityBorderAId",
                table: "CitiesBorder",
                newName: "IX_CitiesBorder_CityBorderAId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitiesBorder",
                table: "CitiesBorder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesBorder_Cities_CityBorderAId",
                table: "CitiesBorder",
                column: "CityBorderAId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesBorder_Cities_CityBorderBId",
                table: "CitiesBorder",
                column: "CityBorderBId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesBorder_Cities_CityBorderAId",
                table: "CitiesBorder");

            migrationBuilder.DropForeignKey(
                name: "FK_CitiesBorder_Cities_CityBorderBId",
                table: "CitiesBorder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitiesBorder",
                table: "CitiesBorder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "CitiesBorder",
                newName: "CityBorder");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_CitiesBorder_CityBorderBId",
                table: "CityBorder",
                newName: "IX_CityBorder_CityBorderBId");

            migrationBuilder.RenameIndex(
                name: "IX_CitiesBorder_CityBorderAId",
                table: "CityBorder",
                newName: "IX_CityBorder_CityBorderAId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityBorder",
                table: "CityBorder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityBorder_City_CityBorderAId",
                table: "CityBorder",
                column: "CityBorderAId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CityBorder_City_CityBorderBId",
                table: "CityBorder",
                column: "CityBorderBId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
