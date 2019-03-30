using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace GB_Project.Services.UserService.UserAPI.Application.CommandHandlers
{
  public class SetImgCommandHandler : IRequestHandler<SetImgCommand, string>
  {
    private IUserRepository _repo;

    public SetImgCommandHandler(IUserRepository repo)
    {
      _repo = repo;
    }
    public Task<string> Handle (SetImgCommand command, CancellationToken cannellationToken)
    {
      return Task.FromResult(_repo.SetUserImg(command.User, command.FileName, command.ImgData));
    }
  }
}