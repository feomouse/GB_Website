using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.ManagerService.Models.AggregateRoot;

namespace GB_Project.Services.ManagerService.Models.EntityTypeConfiguration
{
  public class ViolateUserEntityTypeConfiguration : IEntityTypeConfiguration<ViolateUser>
  {
    public void Configure(EntityTypeBuilder<ViolateUser> builder)
    {
      builder.ToTable("violateUser", schema: "manager");

      builder.HasKey(b => b.PkId);

      builder.HasIndex(b => b.Name).IsUnique();

      builder.Property(b => b.Name).HasColumnType("nvarchar(30)");

      builder.Property(b => b.Date).HasColumnType("date");

      builder.Property(b => b.Detail).HasColumnType("nvarchar(150)");

      builder.Property(b => b.Role).HasColumnType("int");

      builder.Property(b => b.ManagerId).HasColumnType("Uniqueidentifier");
    }
  }
}