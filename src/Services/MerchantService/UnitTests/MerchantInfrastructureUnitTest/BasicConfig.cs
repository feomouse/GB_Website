using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using Microsoft.Extensions.DependencyInjection;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Context;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace GB_Project.Services.MerchantService.UnitTests.MerchantInfrastructureUnitTest
{
  public class BasicConfig
  {
    private IMerchantRepository repository;

    public IMerchantRepository Repository
    {
      get {
        return repository;
      }

      set {
        repository = value;
      }
    }

    public BasicConfig()
    {
      string connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Merchant;User=sa;Password=107409;";
      var services = new ServiceCollection();

      services.
      AddEntityFrameworkSqlServer().
      AddDbContext<MerchantDbContext>((lprovider, options) => {
        options.UseSqlServer(connectionString)
               .UseInternalServiceProvider(lprovider);
      });

      var provider = services.BuildServiceProvider();

      var context = provider.GetRequiredService<MerchantDbContext>();

      context.merchantBasics = context.Set<MerchantBasic>();
      context.merchantIdentitys = context.Set<MerchantIdentity>();

      Repository = new MerchantRepository(context);
    }
  }
}