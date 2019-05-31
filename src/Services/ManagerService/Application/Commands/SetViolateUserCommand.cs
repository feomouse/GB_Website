using MediatR;
using System;

namespace GB_Project.Services.ManagerService.Application.Commands
{
  public class SetViolateUserCommand : IRequest<bool>
  {
    public string UserName { get; set; }

    public string Date { get; set; }

    public string Detail { get; set; }

    public int Role { get; set; }

    public string ManagerId { get; set; }

    public SetViolateUserCommand(string userName, string date, string detail,
                                 int role, string managerId)
    {
      UserName = userName;
      Date = date;
      Detail = detail;
      Role = role;
      ManagerId = managerId;
    }

  }
}