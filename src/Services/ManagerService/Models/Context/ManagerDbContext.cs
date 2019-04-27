using Microsoft.EntityFrameworkCore;
using GB_Project.Services.ManagerService.Models.AggregateRoot;
using GB_Project.Services.ManagerService.Models.EntityTypeConfiguration;

namespace GB_Project.Services.ManagerService.Models.Context
{
  public class ManagerDbContext : DbContext
  {
    public DbSet<ViolateUser> violateUsers { get; set; }

    public ManagerDbContext (DbContextOptions<ManagerDbContext> options) : base (options)
    {
    }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Manager;User=sa;Password=107409;");
    }
    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ViolateUserEntityTypeConfiguration());
    }
  }
}