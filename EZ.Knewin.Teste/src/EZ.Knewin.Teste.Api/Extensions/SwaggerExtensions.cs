using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#pragma warning disable 1591
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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
                {
                    Type = SecuritySchemeType.OAuth2,
                    In = ParameterLocation.Header,
                    Scheme = "oauth2",
                    Name = "Authorization",
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri(configuration["AppSettings:Url"] + @"/account/login")
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Flows = new OpenApiOAuthFlows
                            { 
                                Password = new OpenApiOAuthFlow
                                {
                                    TokenUrl = new Uri(configuration["AppSettings:Url"] + @"/account/login")
                                }
                            },
                        },
                        new List<string>()
                    }
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
                c.SwaggerEndpoint($"{basePath}/swagger/v1/swagger.json", "API");
                c.InjectStylesheet($"{basePath}/swagger-ui/custom.css");
                c.DocExpansion(DocExpansion.List);
                c.DocumentTitle = "Knewin - Teste";
                c.OAuthClientId("swagger-ui");
                c.OAuthClientSecret("swagger-ui-secret");
                c.OAuthRealm("swagger-ui-realm");
                c.OAuthAppName("Swagger UI");
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
