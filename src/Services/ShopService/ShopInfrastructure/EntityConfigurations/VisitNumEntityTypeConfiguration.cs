using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class VisitNumEntityTypeConfiguration : IEntityTypeConfiguration<VisitNum>
    {
      public void Configure(EntityTypeBuilder<VisitNum> visitNumConfiguration)
      {
        visitNumConfiguration.ToTable("visitNum", schema: "shop");

        visitNumConfiguration.HasKey(b => new {b.MShopId, b.Year, b.Month});

        visitNumConfiguration.Property(b => b.Year).HasColumnType("varchar(4)");

        visitNumConfiguration.Property(b => b.Month).HasColumnType("varchar(2)");

        visitNumConfiguration.Property(b => b.Num).HasColumnType("int");
      }
    }
}