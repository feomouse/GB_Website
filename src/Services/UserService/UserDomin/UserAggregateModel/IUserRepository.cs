using System.Collections.Generic;

namespace GB_Project.Services.UserService.UserDomin.UserAggregateModel
{
  public interface IUserRepository
  {
      int CreateUser(User user);

      int SetUserLocation(User user, string location);

      string SetUserImg(string userId, string filename);

      int SetUserName(User user, string userName);

      User GetUserByUserId(string userId);

      List<User> GetUsers(int page);
  }
}