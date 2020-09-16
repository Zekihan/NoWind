using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class SummaryOfSalesByQuarterConfigurations : IEntityTypeConfiguration<SummaryOfSalesByQuarter>
    {
        public void Configure(EntityTypeBuilder<SummaryOfSalesByQuarter> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Summary of Sales by Quarter");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}