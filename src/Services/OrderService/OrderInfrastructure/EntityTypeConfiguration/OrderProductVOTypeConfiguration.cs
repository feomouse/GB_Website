using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using System;

namespace GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration
{
    public class OrderProductVOTypeConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
      public void Configure(EntityTypeBuilder<OrderProduct> builder)
      {
        builder.ToTable("OrderProduct", schema: "order");

        builder.HasKey(new[] {"PpkId", "SpkId", "OpkId"});

/*         builder.
        HasOne(o => o.BasicOrder).
        WithMany(o => o.OrderItems).
        HasForeignKey("OpkId"); */
      }
    }
}