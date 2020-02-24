using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ.Knewin.Teste.Infra.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CidadeCidades");

            migrationBuilder.CreateTable(
                name: "Fronteiras",
                columns: table => new
                {
                    CidadeId = table.Column<int>(nullable: false),
                    CidadeFronteiraId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fronteiras", x => new { x.CidadeId, x.CidadeFronteiraId });
                    table.UniqueConstraint("AK_Fronteiras_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fronteiras_Cidades_CidadeFronteiraId",
                        column: x => x.CidadeFronteiraId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fronteiras_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fronteiras_CidadeFronteiraId",
                table: "Fronteiras",
                column: "CidadeFronteiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fronteiras");

            migrationBuilder.CreateTable(
                name: "CidadeCidades",
                columns: table => new
                {
                    CidadePaiId = table.Column<int>(type: "int", nullable: false),
                    CidadeFronteiraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeCidades", x => new { x.CidadePaiId, x.CidadeFronteiraId });
                    table.ForeignKey(
                        name: "FK_CidadeCidades_Cidades_CidadeFronteiraId",
                        column: x => x.CidadeFronteiraId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CidadeCidades_Cidades_CidadePaiId",
                        column: x => x.CidadePaiId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CidadeCidades_CidadeFronteiraId",
                table: "CidadeCidades",
                column: "CidadeFronteiraId");
        }
    }
}
