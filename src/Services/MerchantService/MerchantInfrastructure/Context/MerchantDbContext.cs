using Microsoft.Extensions.Configuration;
using GB_project.Services.MerchantService.MerchantInfrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using GB_project.Services.MerchantService.MerchantDomin.Aggregateroot;

namespace GB_project.Services.MerchantService.MerchantInfrastructure.Context
{
    public class MerchantDbContext : DbContext
    {
      public DbSet<MerchantBasic> merchantBasics { get; private set; }

      public DbSet<MerchantIdentity> merchantIdentitys { get; private set; }

      public IConfiguration _configuration { get; }

      public MerchantDbContext (DbContextOptions<MerchantDbContext> options, IConfiguration configuration) : base (options)
      {
        _configuration = configuration;
      }
      protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
      {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServerConnection"), m => m.MigrationsAssembly("MerchantAPI"));
      }
      protected override void OnModelCreating (ModelBuilder modelBuilder)
      {
        modelBuilder.ApplyConfiguration(new MerchantBasicEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MerchantIdentityEntityTypeConfiguration());
      }
    }
}