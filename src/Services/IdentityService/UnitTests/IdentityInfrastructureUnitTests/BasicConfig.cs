using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Context;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;

namespace GB_Project.Services.IdentityService.UnitTests.IdentityInfrastructureUnitTests
{
  public class BasicConfig
  {
    private AppUserStore userRepository;

    private AppRoleStore roleRepository;

    public AppUserStore UserRepository{
      get {
        return userRepository;
      }
      set {
        userRepository = value;
      }
    }

    public AppRoleStore RoleRepository{
      get {
        return roleRepository;
      }
      set {
        roleRepository = value;
      }
    }

    public BasicConfig()
    {
      string connectionString = "";
      var services = new ServiceCollection();

      services.
      AddEntityFrameworkSqlServer().
      AddDbContext<MyIdentityDbContext>((lprovider, options) => {
        options.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Identity;Integrated Security=False;User=sa;Password=107409;").
                UseInternalServiceProvider(lprovider);
      }); 

      services.AddIdentity<AppUser, AppRole>().
      AddEntityFrameworkStores<MyIdentityDbContext>().
      AddDefaultTokenProviders();

      services.AddSingleton<AppUserStore>();
      services.AddSingleton<AppRoleStore>();

      var provider = services.BuildServiceProvider();

      DbContextExtensions.userManager = provider.GetRequiredService<UserManager<AppUser>>();

      DbContextExtensions.roleManager = provider.GetRequiredService<RoleManager<AppRole>>();

      DbContextExtensions.signInManager = provider.GetRequiredService<SignInManager<AppUser>>();

      userRepository = provider.GetRequiredService<AppUserStore>();

      roleRepository = provider.GetRequiredService<AppRoleStore>();
    }
  }
}