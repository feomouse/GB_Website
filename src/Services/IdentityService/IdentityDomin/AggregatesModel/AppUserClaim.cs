using System;
using Microsoft.AspNetCore.Identity;

namespace GB_project.Services.IdentityService.IdentityDomin.AggregatesModel
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
      public AppUserClaim ()
      {

      }
    }
}