using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class GBProductImgEntityTypeConfiguration : IEntityTypeConfiguration<GBProductImg>
    {
      public void Configure(EntityTypeBuilder<GBProductImg> gbProductImgConfiguration)
      {
        gbProductImgConfiguration.ToTable("gbProductImg", schema: "shop");

        gbProductImgConfiguration.HasKey(b => b.GBProductPkId);

        gbProductImgConfiguration.Property(b => b.Img).HasColumnType("nvarchar(150)");
      }
    }
}