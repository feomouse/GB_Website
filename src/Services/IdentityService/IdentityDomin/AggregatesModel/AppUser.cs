using GB_Project.Services.IdentityService.IdentityDomin.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
    public class AppUser : IdentityUser<Guid>
    {
      public string RefreshToken { get; private set; }
      public AppUser ()
      {

      }

      public AppUser (string userName, string password)
      {
        UserName = userName;
        Email = userName;
        PasswordHash = password;
        ConcurrencyStamp = DateTime.Now.ToString();
        SecurityStamp = Guid.NewGuid().ToString();
      }

      public void SetRefreshToken ( string refreshToken)
      {
        RefreshToken = refreshToken;
      }

      public AppUser ShallowCopy()
      {
        return (AppUser) this.MemberwiseClone();
      }
    }
}