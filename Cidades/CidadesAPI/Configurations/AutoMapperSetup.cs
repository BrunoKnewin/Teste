using AutoMapper;
using Cidades.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CidadesAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}
