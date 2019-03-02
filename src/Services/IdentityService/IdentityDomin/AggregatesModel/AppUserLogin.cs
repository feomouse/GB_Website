using System;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
      public AppUserLogin ()
      {

      }
    }
}