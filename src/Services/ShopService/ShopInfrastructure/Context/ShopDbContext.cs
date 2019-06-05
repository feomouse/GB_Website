using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopInfrastructure.EntityConfigurations;

namespace GB_Project.Services.ShopService.ShopInfrastructure.Context
{
    public class ShopDbContext : DbContext
    {
      public DbSet<Shop> shops { get; set; }

      public DbSet<ProductType> producttypes { get; set; }

      //public DbSet<ShopType> shoptypes { get; set; }

      public DbSet<GBProduct> gbproduct { get; set; }

      public DbSet<ShopType> shopTypes { get; set; }

      public DbSet<ShopImg> shopImgs { get; set; }

      public DbSet<GBProductImg> gbProductImg { get; set; }

      public DbSet<VisitNum> visitNums { get; set; }

      public DbSet<MonthSell> monthSells { get; set; }

      public ShopDbContext (DbContextOptions<ShopDbContext> options) : base (options)
      {

      }

      protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder)
      {
        optionsBuilder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Shop;User=sa;Password=107409;", b => b.MigrationsAssembly("ShopAPI"));
      }

      protected override void OnModelCreating (ModelBuilder modelBuilder)
      {
        modelBuilder.ApplyConfiguration(new ShopEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GBProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ShopTypeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ShopImgEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GBProductImgEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new VisitNumEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MonthSellEntityTypeConfiguration());
      }
    }
}
