using GB_Project.Services.ManagerService.Models.AggregateRoot;

namespace GB_Project.Services.ManagerService.Services
{
  public interface IManagerRepository
  {
    bool SetViolateUser(ViolateUser user);

    bool SetIsWarned(string userName);

    bool SetIsInBlackMenu(string userName);
  }
}