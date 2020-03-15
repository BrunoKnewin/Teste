using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;

namespace AytyTechSafetySuite.Extensions
{
    public static class AuthServiceExtension
    {

        public static IServiceCollection AddCustomAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthorization()
                .AddAuthentication(
                ).AddJwtBearer("Bearer", options =>
                {
                    options.Authority = $"{configuration["Identity:AuthorityUrl"]}"; 
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.ValidateLifetime = true;
                    options.TokenValidationParameters.ValidateIssuer = false;
                });
            return services;
        }
    }
}