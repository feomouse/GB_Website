using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ProductTypeEntityTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
      public void Configure (EntityTypeBuilder<ProductType> ptConfiguration)
      {
        ptConfiguration.ToTable("ProductType", schema: "shop");

        ptConfiguration.HasKey(b => b.PkId);

        ptConfiguration.Property(b => b.TypeName).HasColumnType("nvarchar(20)"); 

        ptConfiguration.Property<Guid>("ShopId").HasColumnType("uniqueidentifier").IsRequired();
      }
    }
}