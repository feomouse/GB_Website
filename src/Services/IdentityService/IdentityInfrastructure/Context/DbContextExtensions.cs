using Microsoft.AspNetCore.Identity;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;

namespace GB_Project.Services.IdentityService.IdentityInfrastructure.Context
{
    public static class DbContextExtensions
    {
      public static UserManager<AppUser> userManager { get; set; }

      public static RoleManager<AppRole> roleManager { get; set; }

      public static SignInManager<AppUser> signInManager { get; set; }
    }
}