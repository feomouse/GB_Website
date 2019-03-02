using System;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
      public AppUserClaim ()
      {

      }
    }
}