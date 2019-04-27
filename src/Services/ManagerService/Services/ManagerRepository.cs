using GB_Project.Services.ManagerService.Models.Context;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.ManagerService.Models.AggregateRoot;
using System.Linq;

namespace GB_Project.Services.ManagerService.Services
{
  public class ManagerRepository : IManagerRepository
  {
    private ManagerDbContext _context;
    public ManagerRepository(ManagerDbContext context)
    {
       _context = context;
    }
    public bool SetViolateUser(ViolateUser user)
    {
      _context.violateUsers.Add(user);

      return (_context.SaveChanges() != 0);
    }

    public bool SetIsWarned(string userName)
    {
      var user = _context.violateUsers.Where(u => u.Name == userName).FirstOrDefault();

      user.SetIsWarned();

      return (_context.SaveChanges() != 0);
    }

    public bool SetIsInBlackMenu(string userName)
    {
      var user = _context.violateUsers.Where(u => u.Name == userName).FirstOrDefault();

      user.SetIsInBlackMenu();

      return (_context.SaveChanges() != 0);
    }
  }
}