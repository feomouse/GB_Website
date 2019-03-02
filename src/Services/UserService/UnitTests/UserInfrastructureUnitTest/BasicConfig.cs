using GB_Project.Services.UserService.UserInfrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using GB_Project.Services.UserService.UserInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UnitTests.UserInfrastructureUnitTest
{
  public class BasicConfig
  {
    private UserRepository repository;

    public UserRepository Repository {
      get {
        return repository;
      }

      set {
        repository = value;
      }
    }

    public BasicConfig()
    {
      string connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=User;User=sa;Password=107409;";
      var services = new ServiceCollection();

      services.
      AddEntityFrameworkSqlServer().
      AddDbContext<UserDbContext>((lprovider, options) => {
        options.UseSqlServer(connectionString).
                UseInternalServiceProvider(lprovider);
      });

      var serviceProvider = services.BuildServiceProvider();

      var context = serviceProvider.GetRequiredService<UserDbContext>();

      context.user = context.Set<User>();

      Repository = new UserRepository(context);
    }
  }
}