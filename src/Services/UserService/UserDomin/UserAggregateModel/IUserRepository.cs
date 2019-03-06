namespace GB_Project.Services.UserService.UserDomin.UserAggregateModel
{
  public interface IUserRepository
  {
      int CreateUser(User user);

      int SetUserLocation(User user, string location);

      int SetUserImg(User user, string img);

      User GetUserByUserId(string userId);
  }
}