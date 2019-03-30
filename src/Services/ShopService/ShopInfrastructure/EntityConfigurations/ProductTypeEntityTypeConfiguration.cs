using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ProductTypeEntityTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
      public void Configure (EntityTypeBuilder<ProductType> ptConfiguration)
      {
        ptConfiguration.ToTable("ProductType", schema: "shop");

        ptConfiguration.HasKey(b => b.PkId);

        ptConfiguration.HasOne<Shop>(b => b._Shop);

        ptConfiguration.Property(b => b.TypeName).HasColumnType("nvarchar(20)"); 
      }
    }
}