using MediatR;

namespace GB_Project.Services.ManagerService.Application.Commands
{
  public class SetUserWarnedCommand : IRequest<bool>
  {
    public string UserName { get; set; }
  
    public SetUserWarnedCommand(string userName)
    {
      UserName = userName;
    }
  }
}