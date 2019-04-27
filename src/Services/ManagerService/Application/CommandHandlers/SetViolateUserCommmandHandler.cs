using MediatR;
using GB_Project.Services.ManagerService.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ManagerService.Services;
using GB_Project.Services.ManagerService.Models.AggregateRoot;
using System;

namespace GB_Project.Services.ManagerService.Application.CommandHandlers
{
  public class SetViolateUserCommandHandler : IRequestHandler<SetViolateUserCommand, bool>
  {
    private IManagerRepository _repo;
    public SetViolateUserCommandHandler(IManagerRepository repo)
    {
      _repo = repo;
    }
    public Task<bool> Handle(SetViolateUserCommand command, CancellationToken cancellaitonToken)
    {
      return Task.FromResult(_repo.SetViolateUser(new ViolateUser(command.UserName, command.Date, command.Detail,
                                           command.Role, false, false, new Guid(command.ManagerId))));
    }
  }
}