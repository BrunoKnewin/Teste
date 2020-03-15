using cidades.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cidades.Infrastructure.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
    	    builder.HasKey(c => c.Id);
    	    builder.Property(c => c.Name);
            builder.Property(c => c.Population);
            builder.Property(c => c.CountryState).HasMaxLength(2);
            builder.HasIndex(c => new { c.Name, c.CountryState }).IsUnique(true);
            builder.HasMany(c => c.CityRoutes).WithOne(cr => cr.City).HasForeignKey(c => c.IdCity);
            builder.Ignore(c => c.Neighbors);
        }

    }
}