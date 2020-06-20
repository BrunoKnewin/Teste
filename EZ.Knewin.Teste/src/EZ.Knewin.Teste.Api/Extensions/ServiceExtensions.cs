using AutoMapper;
using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using EZ.Knewin.Teste.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

#pragma warning disable 1591
namespace EZ.Knewin.Teste.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IArmazenadorDeCidade), typeof(ArmazenadorDeCidade));
            services.AddScoped(typeof(IBuscadorDeEstado), typeof(BuscadorDeEstado));
            services.AddScoped(typeof(IBuscadorDeCidade), typeof(BuscadorDeCidade));
            services.AddScoped(typeof(IAtualizadorDeCidade), typeof(AtualizadorDeCidade));
            services.AddScoped(typeof(IBuscadorDeUsuario), typeof(BuscadorDeUsuario));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CidadeDto, Cidade>();
                cfg.CreateMap<EstadoDto, Estado>();
                cfg.CreateMap<Cidade, CidadeDto>()
                    .ForMember(c => c.FronteirasIds, dt => dt.MapFrom(m => JsonConvert.DeserializeObject<int[]>(m.FronteirasIds)));
                cfg.CreateMap<Estado, EstadoDto>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
