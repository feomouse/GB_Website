using MediatR;

namespace GB_Project.Services.ManagerService.Application.Commands
{
  public class SetUserInBlackMenuCommand : IRequest<bool>
  {
    public string UserName { get; set; }
  
    public SetUserInBlackMenuCommand(string userName)
    {
      UserName = userName;
    }
  }
}