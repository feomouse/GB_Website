using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.ShopService.ShopInfrastructure.Context;

namespace GB_Project.Services.ShopService.UnitTest.ShopInfrastructureUnitTest
{
  public class BasicConfig
  {
    private ShopRepository repository;

    public ShopRepository Repository{
      get {
        return repository;
      }
      set {
        repository = value;
      }
    }

    public BasicConfig()
    {
      var services = new ServiceCollection();
      string connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Shop;User=sa;Password=107409;";

      services.
      AddEntityFrameworkSqlServer().
      AddDbContext<ShopDbContext>((lprovider, options) => {
        options.UseSqlServer(connectionString).
                UseInternalServiceProvider(lprovider);
      });

      services.AddSingleton<ShopRepository>();

      var provider = services.BuildServiceProvider();

      var context = provider.GetRequiredService<ShopDbContext>();

      context.shops = context.Set<Shop>();

      Repository = new ShopRepository(context);
    }
  }
}