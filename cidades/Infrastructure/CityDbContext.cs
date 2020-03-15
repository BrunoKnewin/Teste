using System.Reflection;
using cidades.Model;
using Microsoft.EntityFrameworkCore;

namespace cidades.Infrastructure
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<City> Cities {get;set;}
    }
}