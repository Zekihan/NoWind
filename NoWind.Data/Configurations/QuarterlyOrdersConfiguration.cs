using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class QuarterlyOrdersConfigurations : IEntityTypeConfiguration<QuarterlyOrders>
    {
        public void Configure(EntityTypeBuilder<QuarterlyOrders> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Quarterly Orders");

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.CompanyName).HasMaxLength(40);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(5)
                .IsFixedLength();
        }
    }
}