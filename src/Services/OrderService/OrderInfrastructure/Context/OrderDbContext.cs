using Microsoft.EntityFrameworkCore;
using GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;

namespace GB_Project.Services.OrderService.OrderInfrastructure.Context
{
    public class OrderDbContext : DbContext
    {
      public DbSet<GroupBuyingOrder> GroupBuyingOrders { get; set; }

      public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
      {

      }

      protected override void OnConfiguring(DbContextOptionsBuilder builder)
      {
        builder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Order;User=sa;Password=107409;",
        b => b.MigrationsAssembly("OrderAPI"));
      } 

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.ApplyConfiguration(new GBOrderEntityTypeConfiguration());
      }
    }
}