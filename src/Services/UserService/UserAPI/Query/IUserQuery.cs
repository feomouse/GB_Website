using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using System.Collections.Generic;

namespace GB_Project.Services.UserService.UserAPI.Query
{
  public interface IUserQuery
  {
    User GetUserByUserId(string userId);

    List<User> GetUsers(int page);
  }
}