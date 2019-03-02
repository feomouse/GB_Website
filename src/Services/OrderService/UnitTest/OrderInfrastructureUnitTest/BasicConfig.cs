using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using GB_Project.Services.OrderService.OrderInfrastructure.Context;
using GB_Project.Services.OrderService.OrderInfrastructure.OrderRepository;

namespace GB_Project.Services.OrderService.UnitTest.OrderInfrastructureUnitTest
{
    public class BasicConfig
    {
      public OrderRepository repository;

      public OrderDbContext context;

      public BasicConfig()
      {
        var serviceCollections = new ServiceCollection();

        var connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Order;User=sa;Password=107409;";

        serviceCollections.
        AddEntityFrameworkSqlServer().
        AddDbContext<OrderDbContext>((lserviceProvider, options) => {
          options.UseSqlServer(connectionString).
                  UseInternalServiceProvider(lserviceProvider);
        });

        serviceCollections.AddSingleton<OrderRepository>();

        var serviceProvider = serviceCollections.BuildServiceProvider();

        context = serviceProvider.GetRequiredService<OrderDbContext>();

        context.ordersBasic = context.Set<OrderBasic>();

        context.customerOrders = context.Set<CustomerOrder>();

        context.shopOrders = context.Set<ShopOrder>();

        context.ordersProducts = context.Set<OrderProduct>();

        repository = new OrderRepository(context);
      }
    }
}