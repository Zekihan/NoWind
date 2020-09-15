using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class InvoicesConfigurations : IEntityTypeConfiguration<Invoices>
    {
        public void Configure(EntityTypeBuilder<Invoices> entity)
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).HasMaxLength(60);

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(5)
                .IsFixedLength();

            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ExtendedPrice).HasColumnType("money");

            entity.Property(e => e.Freight).HasColumnType("money");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.RequiredDate).HasColumnType("datetime");

            entity.Property(e => e.Salesperson)
                .IsRequired()
                .HasMaxLength(31);

            entity.Property(e => e.ShipAddress).HasMaxLength(60);

            entity.Property(e => e.ShipCity).HasMaxLength(15);

            entity.Property(e => e.ShipCountry).HasMaxLength(15);

            entity.Property(e => e.ShipName).HasMaxLength(40);

            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

            entity.Property(e => e.ShipRegion).HasMaxLength(15);

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.Property(e => e.ShipperName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}