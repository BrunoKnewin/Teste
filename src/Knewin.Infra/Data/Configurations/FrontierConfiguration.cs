using Knewin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Knewin.Infra.Data.Configurations
{
    public class FrontierConfiguration : IEntityTypeConfiguration<Frontier>
    {
        public void Configure(EntityTypeBuilder<Frontier> builder)
        {
            builder.HasKey(e => new { e.CityId, e.FrontierCityId });

            builder.HasOne(e => e.City)
                .WithMany(e => e.Frontier)
                .HasForeignKey(e => e.CityId);
        }
    }
}
