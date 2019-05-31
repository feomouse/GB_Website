using MediatR;
using GB_Project.Services.ManagerService.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ManagerService.Services;
using GB_Project.Services.ManagerService.Models.AggregateRoot;
using System;
using GB_Project.Services.ManagerService.Querys;
namespace GB_Project.Services.ManagerService.Application.CommandHandlers
{
  public class SetViolateUserCommandHandler : IRequestHandler<SetViolateUserCommand, bool>
  {
    private IManagerRepository _repo;
    private IManagerQuery _query;
    public SetViolateUserCommandHandler(IManagerRepository repo, IManagerQuery query)
    {
      _repo = repo;
      _query = query;
    }
    public Task<bool> Handle(SetViolateUserCommand command, CancellationToken cancellaitonToken)
    {
      DateTime dt = DateTime.Now;
      if(!DateTime.TryParse(command.Date, out dt))
      {
        dt = DateTime.Now;
      }
      if(_query.GetViolateUserByUserName(command.UserName) != null)
      {
        return Task.FromResult(false);
      }

      else return Task.FromResult(_repo.SetViolateUser(new ViolateUser(command.UserName, dt, command.Detail,
                                           command.Role, new Guid(command.ManagerId))));
    }
  }
}