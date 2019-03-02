using Microsoft.EntityFrameworkCore;
using GB_Project.Services.OrderService.OrderInfrastructure.EntityTypeConfiguration;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;

namespace GB_Project.Services.OrderService.OrderInfrastructure.Context
{
    public class OrderDbContext : DbContext
    {
      public DbSet<CustomerOrder> customerOrders;

      public DbSet<OrderBasic> ordersBasic;

      public DbSet<OrderProduct> ordersProducts;

      public DbSet<ShopOrder> shopOrders;

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
        builder.ApplyConfiguration(new OrderBasicEntityTypeConfiguration());
        builder.ApplyConfiguration(new CustomerOrderEntityTypeConfiguration());
        builder.ApplyConfiguration(new ShopOrderEntityTypeConfiguration());
        builder.ApplyConfiguration(new OrderProductVOTypeConfiguration());
      }
    }
}