using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserInfrastructure.Context;
using System.Linq;
using System;

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

    
    public int SetUserLocation(User user, string location)
    {
      user.SetAddress(location);

      return _context.SaveChanges();
    }

    public int SetUserImg(User user, string img)
    {
      user.SetLookingImg(img);

      return _context.SaveChanges();
    }

    public User GetUserByUserId(string userId)
    {
      return _context.user.Where(u => u.PkId == new Guid(userId)).Single();
    }
  } 
}