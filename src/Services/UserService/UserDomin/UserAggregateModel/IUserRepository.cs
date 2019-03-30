namespace GB_Project.Services.UserService.UserDomin.UserAggregateModel
{
  public interface IUserRepository
  {
      int CreateUser(User user);

      int SetUserLocation(User user, string location);

      string SetUserImg(User user, string filename, byte[] img);

      int SetUserName(User user, string userName);

      User GetUserByUserId(string userId);
  }
}