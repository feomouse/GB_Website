using System;

namespace GB_Project.Services.ManagerService.ViewModels
{
  public class IsInBlackMenuViewModel 
  {
    public string UserName { get; private set; }

    public DateTime Date { get; private set; }

    public string Detail { get; private set; }
  
    public int Role { get; private set; }

    public string ManagerId { get; private set; }
  }
}