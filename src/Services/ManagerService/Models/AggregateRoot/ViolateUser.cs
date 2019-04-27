using GB_Project.Services.ManagerService.Models.SeekWork;
using System;

namespace GB_Project.Services.ManagerService.Models.AggregateRoot
{
  public class ViolateUser : IAggregateRoot
  {
    public Guid PkId { get; private set; }

    public string Name { get; private set; }

    public DateTime Date { get; private set; }

    public string Detail { get; private set; }

    public int Role { get; private set; }

    public bool IsWarned { get; private set; }

    public bool IsInBlackMenu { get; private set; }

    public Guid ManagerId { get; private set; }

    public ViolateUser(string name, DateTime date, string detail, 
                       int role, bool isWarned, bool isInBlackMenu, Guid managerId)
    {
      Name = name;
      Date = date;
      Detail = detail;
      Role = role;
      IsWarned = isWarned;
      IsInBlackMenu = isInBlackMenu;
      ManagerId = managerId;
    }

    public ViolateUser(Guid pkId, string name, DateTime date, string detail, 
                       int role, bool isWarned, bool isInBlackMenu, Guid managerId)
    {
      PkId = pkId;
      Name = name;
      Date = date;
      Detail = detail;
      Role = role;
      IsWarned = isWarned;
      IsInBlackMenu = isInBlackMenu;
      ManagerId = managerId;
    }

    public void SetManagerId(Guid managerId) 
    {
      ManagerId = managerId;
    }

    public void SetIsWarned()
    {
      IsWarned = true;
    }

    public void SetIsInBlackMenu()
    {
      IsInBlackMenu = true;
    }
  }
}