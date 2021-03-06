using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class GBRuleEntityTypeConfiguration : IEntityTypeConfiguration<GBRule>
    {
      public void Configure (EntityTypeBuilder<GBRule> gbConfiguration)
      {
        gbConfiguration.ToTable("GBRule", schema: "shop");

        gbConfiguration.HasKey(b => b.PkId);

        gbConfiguration.Property(b => b.Content).HasColumnType("nvarchar(30)"); 

        gbConfiguration.Property<Guid>("GBProductId").HasColumnType("uniqueidentifier").IsRequired();
      }
    }
}