using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Knewin.CityApi.Mappings;
using Knewin.CityApi.Swagger.Filters;
using Knewin.Infra.Data.Contexts;
using Knewin.Infra.Repositories;
using Knewin.Infra.Services;
using Knewin.Swagger.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Knewin.CityApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CityContext")));

            var jwtIssuerOptions = Configuration.GetSection("JwtIssuerOptions");

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSecretKey").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var accountService = context.HttpContext.RequestServices.GetRequiredService<IAccountCrudService>();
                        var accountId = int.Parse(context.Principal.Identity.Name);
                        var user = accountService.Get(accountId);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped(typeof(ICityRepository), typeof(CityRepository));
            services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));

            services.AddScoped<ICityCrudService, CityCrudService>();
            services.AddScoped<IAccountCrudService, AccountCrudService>();

            services.AddApiVersioning();
            services.AddSwaggerGen(s =>
            {
                s.AddSwaggerGenOption(typeof(Version), ApiHelper.ProductName, ApiHelper.CompanyName);
                s.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });

                s.OperationFilter<OperationFilter>();
                s.DocumentFilter<DocumentFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(s => { s.AddSwaggerUIOptions(typeof(Version), ApiHelper.ProductName); });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
