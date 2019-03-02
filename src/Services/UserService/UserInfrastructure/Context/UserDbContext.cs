using Microsoft.EntityFrameworkCore;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserInfrastructure.EntityTypeConfiguration;

namespace GB_Project.Services.UserService.UserInfrastructure.Context
{
  public class UserDbContext : DbContext
  {
    public DbSet<User> user { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring (DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=User;User=sa;Password=107409;", b => b.MigrationsAssembly("UserAPI"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new UserEntityTypeConfiguration());
    } 
  }
}