using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System;

namespace GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations
{
    public class MonthSellEntityTypeConfiguration : IEntityTypeConfiguration<MonthSell>
    {
      public void Configure(EntityTypeBuilder<MonthSell> monthSellConfiguration)
      {
        monthSellConfiguration.ToTable("monthSell", schema: "shop");

        monthSellConfiguration.HasKey(b => new {b.MShopId, b.Year, b.Month});

        monthSellConfiguration.Property(b => b.Year).HasColumnType("varchar(4)");

        monthSellConfiguration.Property(b => b.Month).HasColumnType("varchar(2)");

        monthSellConfiguration.Property(b => b.Num).HasColumnType("int");
      }
    }
}