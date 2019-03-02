using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ShopEntityTypeConfiguration : IEntityTypeConfiguration<Shop>
    {
      public void Configure(EntityTypeBuilder<Shop> shopConfiguration)
      {
        shopConfiguration.ToTable("shop", schema: "shop");

        shopConfiguration.HasKey(b => b.PkId);

        shopConfiguration.Property(b => b.Name).HasColumnType("nvarchar(20)");

        shopConfiguration.Property(b => b.Province).HasColumnType("nvarchar(10)");

        shopConfiguration.Property(b => b.City).HasColumnType("nvarchar(10)");

        shopConfiguration.Property(b => b.District).HasColumnType("nvarchar(10)");

        shopConfiguration.Property(b => b.Location).HasColumnType("nvarchar(30)");

        shopConfiguration.Property(b => b.Type).HasColumnType("smallint");

        shopConfiguration.Property(b => b.RegisterId).HasColumnType("Uniqueidentifier");

        shopConfiguration.Property(b => b.Tel).HasColumnType("varchar(11)");

        shopConfiguration.Property(b => b.Pic).HasColumnType("varchar(50)");

        var navigationGbProduct = shopConfiguration.Metadata.FindNavigation(nameof(Shop._gbProduct));

        var navigation_producttype = shopConfiguration.Metadata.FindNavigation(nameof(Shop._producttype));
            
        navigationGbProduct.SetPropertyAccessMode(PropertyAccessMode.Field);

        navigation_producttype.SetPropertyAccessMode(PropertyAccessMode.Field);
      }
    }
}