using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace EZ.Knewin.Teste.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });

                options.IncludeXmlComments(GetPathForDocuments());
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app, IConfiguration configuration)
        {
            var basePath = configuration["AppSettings:BasePath"];

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                //c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint($"{basePath}/swagger/v1/swagger.json", "API");
                c.InjectStylesheet($"{basePath}/swagger-ui/custom.css");
                c.DocExpansion(DocExpansion.List);
                c.DocumentTitle = "Knewin - Teste";
                //c.OAuthClientId("swagger-ui");
                //c.OAuthClientSecret("swagger-ui-secret");
                //c.OAuthRealm("swagger-ui-realm");
                //c.OAuthAppName("Swagger UI");
            });

            return app;
        }

        private static string GetPathForDocuments()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(AppContext.BaseDirectory, xmlFile);
        }
        
    }
}
