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
  }
}