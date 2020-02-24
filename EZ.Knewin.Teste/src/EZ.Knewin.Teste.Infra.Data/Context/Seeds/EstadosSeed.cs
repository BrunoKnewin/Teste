using EZ.Knewin.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EZ.Knewin.Teste.Infra.Data.Context.Seeds
{
    public static class EstadosSeed
    {
        public static void Executar(MigrationBuilder migrationBuilder)
        {
            var columnns = new string[] { "Nome", "Sigla" };

            migrationBuilder.InsertData("Estados", columnns, new object[] { "Acre", "AC" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Alagoas", "AL" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Amapa", "AP" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Amazonas", "AM" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Bahia", "BA" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Ceará", "CE" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Distrito Federal", "DF" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Espírito Santo", "ES" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Goiás", "GO" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Maranhão", "MA" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Mato Grosso", "MT" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Mato Grosso do Sul", "MS" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Minas Gerais", "MG" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Pará", "PA" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Paraiba", "PB" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Paraná", "PR" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Pernambuco", "PE" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Piauí", "PI" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Rio de Janeiro", "RJ" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Rio Grande do Norte", "RN" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Rio Grande do Sul", "RS" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Rondônia", "RO" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Roraima", "RR" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Santa Catarina", "SC" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "São Paulo", "SP" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Sergipe", "SE" });
            migrationBuilder.InsertData("Estados", columnns, new object[] { "Tocantins", "TO" });
        }
    }
}
