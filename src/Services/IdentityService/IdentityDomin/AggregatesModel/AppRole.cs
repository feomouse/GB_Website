using GB_Project.Services.IdentityService.IdentityDomin.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
  public class AppRole : IdentityRole<Guid>
  {
     public AppRole(string name)
     {
        Id = Guid.NewGuid();
        Name = name;
        NormalizedName = name;
     }
  }   
}