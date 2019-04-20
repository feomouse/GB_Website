using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Collections.Generic;
using System;

namespace GB_Project.Services.IdentityService.IdentityAPI.Query
{
  public interface IUserQuery
  {
    AppUser FindUserByEmail(string email);

    AppUser FindUserByName(string userName);

    AppUser FindUserById(string userId, string role);

    IList<String> GetRolesAsync(AppUser user);

    AppUser GetAppUserByRefreshToken(string refreshToken);
  }
}