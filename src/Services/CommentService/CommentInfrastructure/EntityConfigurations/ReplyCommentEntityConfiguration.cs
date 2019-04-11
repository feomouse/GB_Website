using Microsoft.EntityFrameworkCore;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GB_Project.Services.CommentService.CommentInfrastructrue.EntityConfigurations
{
  public class ReplyCommentEntityConfiguration : IEntityTypeConfiguration<ReplyComment>
  {
    public ReplyCommentEntityConfiguration()
    {

    }

    public void Configure(EntityTypeBuilder<ReplyComment> builder)
    {
      builder.ToTable("ReplyComment", schema: "comment");

      builder.HasKey("PkId");

      builder.Property("Reply").HasColumnType("nvarchar(150)");

      builder.Property("Date").HasColumnType("date");
    }
  }
}