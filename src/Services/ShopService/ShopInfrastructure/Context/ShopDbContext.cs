using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_project.Services.ShopService.ShopInfrastructure.EntityConfigurations;

namespace GB_project.Services.ShopService.ShopInfrastructure.Context
{
    public class ShopDbContext : DbContext
    {
      public DbSet<Shop> shop { get; set; }

      public DbSet<ShopMerchant> shopmerchant { get; set; }

      public DbSet<Product> product { get; set; }

      public DbSet<ProductType> producttype { get; set; }

      public DbSet<GBProduct> gbproduct { get; set; }

      public DbSet<GBRule> gbrule { get; set; }

      public DbSet<GBProductItem> gbitems { get; set;}

      public ShopDbContext (DbContextOptions<ShopDbContext> options) : base (options)
      {

      }

      protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder)
      {
        optionsBuilder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Integrated Security=False;User=sa;Password=107409;", b => b.MigrationsAssembly("ShopAPI"));
      }

      protected override void OnModelCreating (ModelBuilder modelBuilder)
      {
        modelBuilder.ApplyConfiguration(new ShopEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GBProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GBRuleEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ShopMerchantEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GBProductItemEntityTypeConfiguration());
      }
    }
}
