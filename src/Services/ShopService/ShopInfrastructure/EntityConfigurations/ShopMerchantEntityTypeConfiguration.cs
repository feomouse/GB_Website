using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class ShopMerchantEntityTypeConfiguration : IEntityTypeConfiguration<ShopMerchant>
    {
      public void Configure(EntityTypeBuilder<ShopMerchant> smConfiguration)
      {
        smConfiguration.ToTable("shopMerchant", schema: "shop");

        smConfiguration.HasKey(b => new {b.MerchantId, b.ShopId});

        smConfiguration.Property(b => b.IsRegister).HasColumnType("bit");

        smConfiguration.Property<Guid>("ShopId").HasColumnType("uniqueidentifier");
      }
    }
}