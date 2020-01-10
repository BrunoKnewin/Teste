using Knewin.Domain.Entities;
using Knewin.Infra.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knewin.Infra.Data.Contexts
{
    public class CityContext : IdentityDbContext
    {

        public DbSet<City> City { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FrontierConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
