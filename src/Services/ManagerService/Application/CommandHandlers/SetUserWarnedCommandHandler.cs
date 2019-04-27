using MediatR;
using GB_Project.Services.ManagerService.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ManagerService.Services;

namespace GB_Project.Services.ManagerService.Application.CommandHandlers
{
  public class SetUserWarnedCommandHandler : IRequestHandler<SetUserWarnedCommand, bool>
  {
    private IManagerRepository _repo;
    public SetUserWarnedCommandHandler(IManagerRepository repo)
    {
      _repo = repo;
    }
    public Task<bool> Handle(SetUserWarnedCommand command, CancellationToken cancellaitonToken)
    {
      return Task.FromResult(_repo.SetIsWarned(command.UserName));
    }
  }
}