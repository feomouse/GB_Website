using System;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
    public class AppUserToken : IdentityUserToken<Guid>
    {
      public AppUserToken ()
      {

      }
    }
}