using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class GBProductItemEntityTypeConfiguration : IEntityTypeConfiguration<GBProductItem>
    {
      public void Configure (EntityTypeBuilder<GBProductItem> gbConfiguration)
      {
        gbConfiguration.ToTable("GBProductItem", schema: "shop");

        gbConfiguration.HasKey(b => b.PkId);

        gbConfiguration.Property<Guid>("GbProductId").HasColumnType("uniqueidentifier").IsRequired();
      }
    }
}