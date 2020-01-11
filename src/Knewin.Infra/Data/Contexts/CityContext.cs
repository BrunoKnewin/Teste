using Knewin.Domain.Entities;
using Knewin.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Knewin.Infra.Data.Contexts
{
    public class CityContext : DbContext
    {

        public DbSet<City> City { get; set; }

        public DbSet<Account> Account { get; set; }

        public CityContext(DbContextOptions<CityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
