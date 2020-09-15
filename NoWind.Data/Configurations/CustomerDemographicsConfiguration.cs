using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    class CustomerDemographicsConfigurations : IEntityTypeConfiguration<CustomerDemographics>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographics> entity)
        {
            entity.HasKey(e => e.CustomerTypeId)
                    .IsClustered(false);

            entity.Property(e => e.CustomerTypeId)
                .HasColumnName("CustomerTypeID")
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
        }
    }
}