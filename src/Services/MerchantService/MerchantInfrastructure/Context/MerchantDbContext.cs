using Microsoft.Extensions.Configuration;
using GB_Project.Services.MerchantService.MerchantInfrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;

namespace GB_Project.Services.MerchantService.MerchantInfrastructure.Context
{
    public class MerchantDbContext : DbContext
    {
      public DbSet<MerchantBasic> merchantBasics { get; set; }

      public DbSet<MerchantIdentity> merchantIdentitys { get; set; }

      public IConfiguration _configuration { get; }

      public MerchantDbContext (DbContextOptions<MerchantDbContext> options) : base (options)
      {
      }
      protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
      {
        optionsBuilder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Merchant;Integrated Security=False;User=sa;Password=107409;", m => m.MigrationsAssembly("MerchantAPI"));
      }
      protected override void OnModelCreating (ModelBuilder modelBuilder)
      {
        modelBuilder.ApplyConfiguration(new MerchantBasicEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MerchantIdentityEntityTypeConfiguration());
      }
    }
}