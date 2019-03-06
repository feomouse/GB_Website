using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Query
{
  public interface IUserQuery
  {
    User GetUserByUserId(string userId);
  }
}