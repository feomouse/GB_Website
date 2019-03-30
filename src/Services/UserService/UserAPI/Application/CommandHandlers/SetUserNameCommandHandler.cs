using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserAPI.Application.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace GB_Project.Services.UserService.UserAPI.Application.CommmandHandlers
{
  public class SetUserNameCommandHandler : IRequestHandler<SetUserNameCommand, int>
  {
    IUserRepository _repo;

    public SetUserNameCommandHandler(IUserRepository repo)
    {
      _repo = repo;
    }

    public Task<int> Handle(SetUserNameCommand command,   CancellationToken cannellationToken)
    {
      var user = _repo.GetUserByUserId(command.UserId);
      return Task.FromResult(_repo.SetUserName(user, command.UserName));
    }
  }
}