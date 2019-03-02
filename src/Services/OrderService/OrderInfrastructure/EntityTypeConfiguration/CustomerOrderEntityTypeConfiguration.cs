using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using System;

namespace GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration
{
    public class CustomerOrderEntityTypeConfiguration : IEntityTypeConfiguration<CustomerOrder>
    {
      public void Configure(EntityTypeBuilder<CustomerOrder> builder)
      {
        builder.ToTable("CustomerOrder", schema: "order");

        builder.HasKey(o => o.PkId);

  /*       builder.
        HasOne(o => o.BasicOrder).
        WithOne(o => o.COrder).
        HasForeignKey<OrderBasic>("BasicOrderId"); */

        builder.Property("PayWay").HasColumnType("int");

        builder.Property("CpkId").HasColumnType("uniqueidentifier");

        builder.Property("Time").HasColumnType("DateTime2");
      }
    }
}