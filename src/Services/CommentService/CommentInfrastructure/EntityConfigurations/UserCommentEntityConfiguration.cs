using Microsoft.EntityFrameworkCore;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GB_Project.Services.CommentService.CommentInfrastructrue.EntityConfigurations
{
  public class UserCommentEntityConfiguration : IEntityTypeConfiguration<UserComment>
  {
    public UserCommentEntityConfiguration()
    {

    }

    public void Configure(EntityTypeBuilder<UserComment> builder)
    {
      builder.ToTable("UserComment", schema: "comment");

      builder.HasKey("PkId");

      builder.Property("Comment").HasColumnType("nvarchar(150)");

      builder.Property("Date").HasColumnType("date");

      builder.Property("Stars").HasColumnType("int");

      builder.Property("Img").HasColumnType("varchar(100)");

      builder.Property("OrderId").HasColumnType("uniqueidentifier");

      builder.Property("ProductId").HasColumnType("uniqueidentifier");

      builder.Property("ShopId").HasColumnType("uniqueidentifier");

      builder.Property("UserName").HasColumnType("nvarchar(20)");
    }
  }
}