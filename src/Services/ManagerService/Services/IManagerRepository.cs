using GB_Project.Services.ManagerService.Models.AggregateRoot;

namespace GB_Project.Services.ManagerService.Services
{
  public interface IManagerRepository
  {
    bool SetViolateUser(ViolateUser user);
  }
}