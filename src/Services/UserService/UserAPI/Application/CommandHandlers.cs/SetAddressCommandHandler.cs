using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace GB_Project.Services.UserService.UserAPI.Application.CommandHandlers
{
  public class SetAddressCommandHandler : IRequestHandler<SetAddressCommand, int>
  {
    private IUserRepository _repo;

    public SetAddressCommandHandler(IUserRepository repo)
    {
      _repo = repo;
    }

    public Task<int> Handle (SetAddressCommand command,  CancellationToken cannellationToken)
    {
      return Task.FromResult(_repo.SetUserLocation(command._user, command.Address));
    }
  }
}