using Knewin.Domain.Entities;
using Knewin.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Knewin.Infra.Data.Seeds
{
    public class CitySeeder
    {
        public static void Seed(CityContext context)
        {
            if (!context.City.Any())
            {
                var cities = new List<City>() {
                    new City() { Name = "Cordilheira Alta", Population = 4453, Frontier = new long[] { 2,3,12 } },
                    new City() { Name = "Xaxim", Population = 28706, Frontier = new long[] { 1,3,7,12,13 } },
                    new City() { Name = "Coronel Freitas", Population = 9981, Frontier = new long[] { 1,2,12,14,15,16,17,18,19 } },
                    new City() { Name = "Guatambu", Population = 4704, Frontier = new long[] { 12,20,21,22 } },
                    new City() { Name = "Planalto Alegre", Population = 2870, Frontier = new long[] { 6,4,12,17,20,24,25 } },
                    new City() { Name = "Nova Itaberaba", Population = 4331, Frontier = new long[] { 3,12,17,21 } },
                    new City() { Name = "Arvoredo", Population = 2256, Frontier = new long[] { 2,8,12,13,26 } },
                    new City() { Name = "Seara", Population = 17541, Frontier = new long[] { 7,9,12,26,27,28 } },
                    new City() { Name = "Paial", Population = 1505, Frontier = new long[] { 8,12,27,29,11 } },
                    new City() { Name = "Nonoai", Population = 11695, Frontier = new long[] { 12,11,23,22,21,32,31 } },
                    new City() { Name = "Erval Grande (RS)", Population = 4859, Frontier = new long[] { 12,30,23,10,9,29 } },
                    new City() { Name = "Chapecó", Population = 200367, Frontier = new long[] { 1,2,3,4,5,6,7,8,9,10,11 } },
                    new City() { Name = "Xanxerê", Population = 50309, Frontier = new long[] { 33,2,7,26,34,35,36 } },
                    new City() { Name = "Quilombo", Population = 10201, Frontier = new long[] { } },
                    new City() { Name = "Marema", Population = 2467, Frontier = new long[] { } },
                    new City() { Name = "Nova Itaberaba", Population = 4298, Frontier = new long[] { } },
                    new City() { Name = "Nova Erechim", Population = 4331, Frontier = new long[] { } },
                    new City() { Name = "Águas Frias", Population = 2378, Frontier = new long[] { } },
                    new City() { Name = "União do Oeste", Population = 2464, Frontier = new long[] { } },
                    new City() { Name = "Caxambu do Sul", Population = 4902, Frontier = new long[] { } },
                    new City() { Name = "Planalto Alegre", Population = 2870, Frontier = new long[] { } },
                    new City() { Name = "Rio dos Índios", Population = 2752, Frontier = new long[] { } },
                    new City() { Name = "Faxinalzinho", Population = 2315, Frontier = new long[] { } },
                    new City() { Name = "São Carlos", Population = 251983, Frontier = new long[] { } },
                    new City() { Name = "Águas de Chapecó", Population = 6200, Frontier = new long[] { } },
                    new City() { Name = "Xavantina", Population = 4316, Frontier = new long[] { } },
                    new City() { Name = "Itá", Population = 6829, Frontier = new long[] { } },
                    new City() { Name = "Arabutã", Population = 4196, Frontier = new long[] { } },
                    new City() { Name = "Itatiba do Sul", Population = 3420, Frontier = new long[] { } },
                    new City() { Name = "São Valentim", Population = 3996, Frontier = new long[] { } },
                    new City() { Name = "Trindade do sul", Population = 6276, Frontier = new long[] { } },
                    new City() { Name = "Gramado dos Loureiros", Population = 2269, Frontier = new long[] { } },
                    new City() { Name = "Faxinal dos Guedes", Population = 10686, Frontier = new long[] { } },
                    new City() { Name = "Bom Jesus", Population = 3010, Frontier = new long[] { } },
                    new City() { Name = "Ipuaçu", Population = 6275, Frontier = new long[] { } },
                    new City() { Name = "Lajeado Grande", Population = 1490, Frontier = new long[] { } },
                };

                cities.ForEach(x => {
                    context.Add(x);
                    context.SaveChanges();
                });
            }
        }
    }
}
