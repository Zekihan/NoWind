using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class CurrentProductListConfigurations : IEntityTypeConfiguration<CurrentProductList>
    {
        public void Configure(EntityTypeBuilder<CurrentProductList> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Current Product List");

            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}