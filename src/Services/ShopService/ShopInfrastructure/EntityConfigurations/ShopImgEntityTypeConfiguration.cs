using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ShopImgEntityTypeConfiguration : IEntityTypeConfiguration<ShopImg>
    {
      public void Configure(EntityTypeBuilder<ShopImg> shopImgConfiguration)
      {
        shopImgConfiguration.ToTable("shopImg", schema: "shop");

        shopImgConfiguration.HasKey(b => new {b.MShopId, b.Img});

        shopImgConfiguration.Property(b => b.Img).HasColumnType("nvarchar(150)");
      }
    }
}