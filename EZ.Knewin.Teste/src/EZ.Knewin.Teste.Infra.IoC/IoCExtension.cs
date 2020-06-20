using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Infra.Data.Context;
using EZ.Knewin.Teste.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EZ.Knewin.Teste.Infra.IoC
{
    public static class IoCExtension
    {

        public static void AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TesteDbContext>(options => options.UseSqlServer(configuration["ConnectionString:KnewinTeste"]));

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
        }
    }
}