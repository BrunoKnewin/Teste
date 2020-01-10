using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Linq;
using Knewin.Core.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Knewin.Swagger.Helpers
{
    public static class SwaggerHelper
    {
        public static SwaggerGenOptions AddSwaggerGenOption(this SwaggerGenOptions option, Type versions, string title, string description)
        {
            versions.GetConstantsValues<string>().ToList().ForEach(x =>
            {
                option.SwaggerDoc($"v{x}", new Info { Version = $"v{x}", Title = title, Description = description });
            });
            return option;
        }

        public static SwaggerUIOptions AddSwaggerUIOptions(this SwaggerUIOptions option, Type versions, string title)
        {
            versions.GetConstantsValues<string>().ToList().ForEach(x =>
            {
                option.SwaggerEndpoint($"./swagger/v{x}/swagger.json", $"{title} v{x}");
                option.RoutePrefix = string.Empty;
            });
            return option;
        }
    }
}
