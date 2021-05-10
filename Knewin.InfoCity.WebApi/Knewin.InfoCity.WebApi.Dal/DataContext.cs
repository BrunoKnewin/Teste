using Knewin.InfoCity.WebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Knewin.InfoCity.WebApi.Dal
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<CityBorder> CityBorders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<City>()
                .HasMany(cb => cb.CityBoders)
                .WithOne(c => c.CityBorderA)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

    }

}
