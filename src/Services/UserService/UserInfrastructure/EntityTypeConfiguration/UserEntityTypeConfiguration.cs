using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserInfrastructure.EntityTypeConfiguration
{
  public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("User", schema: "user");

      builder.HasKey(b => b.PkId);

      builder.Property(b => b.LookingImg).HasColumnType("varchar(50)");

      builder.Property(b => b.Address).HasColumnType("varchar(50)");
    } 
  }
}