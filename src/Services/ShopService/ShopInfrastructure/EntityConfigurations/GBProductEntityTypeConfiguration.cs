using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class GBProductEntityTypeConfiguration : IEntityTypeConfiguration<GBProduct>
    {
      public void Configure (EntityTypeBuilder<GBProduct> gbConfiguration)
      {
        gbConfiguration.ToTable("GBProduct", schema: "shop");

        gbConfiguration.HasKey(b => b.PkId);

        gbConfiguration.Property(b => b.ProductName).HasColumnType("nvarchar(20)");

        gbConfiguration.Property(b => b.OrinPrice).HasColumnType("smallmoney");

        gbConfiguration.Property(b => b.Price).HasColumnType("smallmoney");

        gbConfiguration.Property(b => b.Quantity).HasColumnType("nvarchar(20)");

        gbConfiguration.Property(b => b.VailSDate).HasColumnType("date");

        gbConfiguration.Property(b => b.VailEDate).HasColumnType("date");

        gbConfiguration.Property(b => b.VailTime).HasColumnType("nvarchar(30)");

        gbConfiguration.Property(b => b.Img).HasColumnType("varchar(50)");

        gbConfiguration.Property(b => b.Remark).HasColumnType("nvarchar(50)"); 

        gbConfiguration.Property<Guid>("ShopId").HasColumnType("uniqueidentifier").IsRequired();

        var navigationRule = gbConfiguration.Metadata.FindNavigation(nameof(GBProduct.GbRule));
      
        navigationRule.SetPropertyAccessMode(PropertyAccessMode.Field);

        var navigationProducts = gbConfiguration.Metadata.FindNavigation(nameof(GBProduct.Items));
      
        navigationProducts.SetPropertyAccessMode(PropertyAccessMode.Field);
      }
    }
}