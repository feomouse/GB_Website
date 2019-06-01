using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ShopTypeEntityTypeConfiguration : IEntityTypeConfiguration<ShopType>
    {
      public void Configure(EntityTypeBuilder<ShopType> shopTypeConfiguration)
      {
        shopTypeConfiguration.ToTable("shopType", schema: "shop");

        shopTypeConfiguration.HasKey(b => b.PkId);

        shopTypeConfiguration.Property(b => b.Name).HasColumnType("nvarchar(10)");

        shopTypeConfiguration.Property(b => b.Img).HasColumnType("nvarchar(150)");
      }
    }
}