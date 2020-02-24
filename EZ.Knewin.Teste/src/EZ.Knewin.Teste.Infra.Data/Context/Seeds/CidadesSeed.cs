using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EZ.Knewin.Teste.Infra.Data.Context.Seeds
{
    public static class CidadesSeed
    {
        public static void Executar(MigrationBuilder migrationBuilder)
        {
            var columnns = new string[] {"Id", "Nome", "QuantidadeDeHabitantes", "FronteirasIds", "EstadoId", "DataDeCadastro" };

            migrationBuilder.InsertData("Cidades", columnns, new object[] { 1, "Corumbá", 150000, "[2,3]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 2, "Ladário", 23000, "[1]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 3, "Miranda", 39000, "[1,4]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 4, "Aquidauana", 40000, "[3,5]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 5, "Anastácio", 15000, "[3,4]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 6, "Campo Grande", 890000, "[5,4,7,8]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 7, "Sidrolândia", 15000, "[4,6]", 12, DateTime.Now });
            migrationBuilder.InsertData("Cidades", columnns, new object[] { 8, "Terenos", 10000, "[4,6]", 12, DateTime.Now });
        }
    }
}
