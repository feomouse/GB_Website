using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration
{
    public class GBOrderEntityTypeConfiguration : IEntityTypeConfiguration<GroupBuyingOrder>
    {
      public void Configure(EntityTypeBuilder<GroupBuyingOrder> builder)
      {
        builder.ToTable("GroupBuyingOrder", schema: "order");

        builder.HasKey(t => t.PkId);

        builder.Property(t => t.GroupProductName).HasColumnType("varchar(20)");

        builder.Property(t => t.Number).HasColumnType("int");

        builder.Property(t => t.TotalCost).HasColumnType("int");

        builder.Property(t => t.IsPayed).HasColumnType("bit");

        builder.Property(t => t.Evaluate).HasColumnType("varchar(36)").IsRequired(false);

        builder.Property(t => t.IsUsed).HasColumnType("bit");

        builder.Property(t => t.OrderCode).HasColumnType("Uniqueidentifier");

        builder.Property(t => t.PayWay).HasColumnType("int");

        builder.Property(t => t.CpkId).HasColumnType("Uniqueidentifier");

        builder.Property(t => t.SName).HasColumnType("varchar(20)");

        builder.Property(t => t.Time).HasColumnType("date");

        builder.Property(t => t.Img).HasColumnType("varchar(100)");
      }
    }
}