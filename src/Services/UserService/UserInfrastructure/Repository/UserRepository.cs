using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserInfrastructure.Context;
using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

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

    public int SetUserName(User user, string userName)
    {
      user.SetUserName(userName);

      return _context.SaveChanges();
    }

    
    public int SetUserLocation(User user, string location)
    {
      user.SetAddress(location);

      return _context.SaveChanges();
    }

    public string SetUserImg(string userId, string filename)
    {
      string imgUrl = filename;

      var user = _context.user.Where(b => b.PkId.ToString() == userId).FirstOrDefault();

      user.SetLookingImg(imgUrl);

      if(_context.SaveChanges() != 0)
      {
        return imgUrl;
      }

      return "";
    }

    public User GetUserByUserId(string userId)
    {
      return _context.user.Where(u => u.PkId == new Guid(userId)).FirstOrDefault();
    }

    public List<User> GetUsers(int page)
    {
      return _context.user.Skip((page-1)*10).Take(10).ToList();
    }

    public int GetUserNum()
    {
      return _context.user.Count();
    }

    public dynamic GetUserImgs(List<string> usersName)
    {
      var result = new List<string>();
      foreach (var item in usersName)
      {
          result.Add(_context.user.Where(u => u.Email == item).FirstOrDefault().LookingImg);
      }
      return result;
    }
  } 
}