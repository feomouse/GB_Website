using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using System;

namespace GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration
{
    public class OrderBasicEntityTypeConfiguration : IEntityTypeConfiguration<OrderBasic>
    {
      public void Configure(EntityTypeBuilder<OrderBasic> builder)
      {
        builder.ToTable("OrderBasic", schema: "order");

        builder.HasKey(o => o.PkId);

        builder.
        HasOne(o => o.COrder).
        WithOne(o => o.BasicOrder).
        HasForeignKey<CustomerOrder>("BasicOrderId");

        builder.
        HasOne(o => o.SOrder).
        WithOne(o => o.BasicOrder).
        HasForeignKey<ShopOrder>("BasicOrderId");

        builder.
        HasMany(o => o.OrderItems).
        WithOne(o => o.BasicOrder).
        HasForeignKey("OpkId");

        builder.Property("Address").HasColumnType("varchar(50)");

        builder.Property("Remark").HasColumnType("varchar(50)");

        builder.Property("Sender").HasColumnType("varchar(10)");

        builder.Property("TotalCost").HasColumnType("smallint");

        builder.Property("Evaluate").HasColumnType("Uniqueidentifier");

        builder.Property("IsFinished").HasColumnType("bit");
      }
    }
}