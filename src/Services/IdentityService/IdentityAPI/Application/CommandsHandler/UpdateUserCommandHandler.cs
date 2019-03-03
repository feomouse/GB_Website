using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.CommandsHandler
{
  public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IdentityResult>
  {
    IUserStore<AppUser> _userRepo;

    public UpdateUserCommandHandler (IUserStore<AppUser> userRepo)
    {
      _userRepo = userRepo;  
    }

    public Task<IdentityResult> Handle (UpdateUserCommand command, CancellationToken cancellationToken)
    {
      return _userRepo.UpdateAsync(command.User, default(CancellationToken));
    }
  }
}