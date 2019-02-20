using GB_project.Services.IdentityService.IdentityDomin.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;

namespace GB_project.Services.IdentityService.IdentityDomin.AggregatesModel
{
    public class AppUser : IdentityUser<Guid>
    {
/*    public Guid Id { get; private set; }

      public string UserName { get; private set; }

      public string Email { get; private set; }

      public string PhoneNumber { get; private set; }

      public string PasswordHash { get; private set; } */

      public string RefreshToken { get; private set; }
      public AppUser ()
      {

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