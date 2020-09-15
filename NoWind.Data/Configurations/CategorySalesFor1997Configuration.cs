using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class CategorySalesFor1997Configurations : IEntityTypeConfiguration<CategorySalesFor1997>
    {
        public void Configure(EntityTypeBuilder<CategorySalesFor1997> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Category Sales for 1997");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.CategorySales).HasColumnType("money");
        }
    }
}