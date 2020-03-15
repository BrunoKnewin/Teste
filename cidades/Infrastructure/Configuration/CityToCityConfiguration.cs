using cidades.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cidades.Infrastructure.Configuration
{
    public class CityToCityConfiguration : IEntityTypeConfiguration<CityToCity>
    {
        public void Configure(EntityTypeBuilder<CityToCity> builder)
        {
    	    builder.HasKey(c =>new {c.IdCity,c.IdCityTo});
    	    
            builder.HasOne(cc => cc.CityTo).WithMany(c => c.CityRoutesFrom).HasForeignKey(c => c.IdCityTo);
        }

    }
}