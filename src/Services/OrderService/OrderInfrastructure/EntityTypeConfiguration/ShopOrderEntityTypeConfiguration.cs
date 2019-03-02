using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using System;

namespace GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration
{
    public class ShopOrderEntityTypeConfiguration : IEntityTypeConfiguration<ShopOrder>
    {
      public void Configure(EntityTypeBuilder<ShopOrder> builder)
      {
        builder.ToTable("ShopOrder", schema: "order");

        builder.HasKey(o => o.PkId);

        builder.Property<Guid>("BasicOrderId");

/*         builder.
        HasOne(o => o.BasicOrder).
        WithOne(o => o.SOrder).
        HasForeignKey<OrderBasic>("BasicOrderId"); */

        builder.Property("IsProcessed").HasColumnType("bit");

        builder.Property("IsAccepted").HasColumnType("bit");

        builder.Property("SpkId").HasColumnType("uniqueidentifier");

        builder.Property("Time").HasColumnType("datetime2");
      }
    }
}