using GB_Project.Services.ManagerService.Models.AggregateRoot;
using System.Collections.Generic;

namespace GB_Project.Services.ManagerService.Querys
{
  public interface IManagerQuery
  {
    ViolateUser GetViolateUserByUserName(string userName);

    IEnumerable<ViolateUser> GetViolateUsers(int page);
  }
}