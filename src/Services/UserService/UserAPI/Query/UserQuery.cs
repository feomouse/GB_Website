using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using System.Collections.Generic;

namespace GB_Project.Services.UserService.UserAPI.Query
{
  public class UserQuery : IUserQuery
  {
    private IUserRepository _repo;

    public UserQuery(IUserRepository repo)
    {
      _repo = repo;
    }

    public User GetUserByUserId(string userId)
    {
      return _repo.GetUserByUserId(userId);
    }

    public List<User> GetUsers(int page)
    {
      return _repo.GetUsers(page);
    }
  }
}