using Cidades.Application.Interfaces;
using Cidades.Application.Services;
using Cidades.Domain.Handlers;
using Cidades.Domain.Repositories;
using Cidades.Domain.Repositories.Common;
using Cidades.Infra.Context;
using Cidades.Infra.Repository;
using Cidades.Infra.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Cidades.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICidadeAppService, CidadeAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            // Domain - Commands
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<CidadeHandler, CidadeHandler>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MongoDbContext>();
        }
    }
}
