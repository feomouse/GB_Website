using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class GBProductItemEntityTypeConfiguration : IEntityTypeConfiguration<GBProductItem>
    {
      public void Configure (EntityTypeBuilder<GBProductItem> gbConfiguration)
      {
        gbConfiguration.ToTable("GBProductItem", schema: "shop");

        gbConfiguration.HasKey(b => b.PkId);

        gbConfiguration.HasOne(b => b.GBProduct);
      }
    }
}