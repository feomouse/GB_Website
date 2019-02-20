using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
      public void Configure (EntityTypeBuilder<Product> pConfiguration)
      {
        pConfiguration.ToTable("Product", schema: "shop");

        pConfiguration.HasKey(b => b.PkId);

        pConfiguration.Property(b => b.ProductName).HasColumnType("nvarchar(20)");

        pConfiguration.Property(b => b.ProductType).HasColumnType("uniqueidentifier");

        pConfiguration.Property(b => b.ProductImg).HasColumnType("varchar(50)");

        pConfiguration.Property(b => b.ProductPrice).HasColumnType("smallmoney");

        pConfiguration.Property(b => b.MSellNum).HasColumnType("smallint");

        pConfiguration.Property(b => b.PraiseNum).HasColumnType("smallint");

        pConfiguration.Property(b => b.IsDisplay).HasColumnType("bit");

        pConfiguration.Property<Guid>("ShopId");
      }
    }
}