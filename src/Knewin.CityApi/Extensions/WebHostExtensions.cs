using Knewin.Infra.Data.Contexts;
using Knewin.Infra.Data.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Knewin.CityApi.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<CityContext>();
                try
                {
                    CitySeeder.Seed(context);
                } catch(Exception ex)
                {

                }
            }
            return host;
        }
    }
}
