using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class OrderSubtotalsConfigurations : IEntityTypeConfiguration<OrderSubtotals>
    {
        public void Configure(EntityTypeBuilder<OrderSubtotals> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Order Subtotals");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}