using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserInfrastructure.Context;

namespace GB_Project.Services.UserService.UserInfrastructure.Repository
{
  public class UserRepository : IUserRepository
  {
    public UserDbContext _context;

    public UserRepository (UserDbContext context)
    {
      _context = context;
    }
    public int CreateUser(User user)
    {
      _context.user.Add(user);

      return _context.SaveChanges();
    }
  } 
}