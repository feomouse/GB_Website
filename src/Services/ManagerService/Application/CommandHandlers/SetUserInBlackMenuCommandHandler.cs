using MediatR;
using GB_Project.Services.ManagerService.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ManagerService.Services;

namespace GB_Project.Services.ManagerService.Application.CommandHandlers
{
  public class SetUserInBlackMenuCommandHandler : IRequestHandler<SetUserInBlackMenuCommand, bool>
  {
    private IManagerRepository _repo;
    public SetUserInBlackMenuCommandHandler(IManagerRepository repo)
    {
      _repo = repo;
    }
    public Task<bool> Handle(SetUserInBlackMenuCommand command, CancellationToken cancellaitonToken)
    {
      return Task.FromResult(_repo.SetIsInBlackMenu(command.UserName));
    }
  }
}