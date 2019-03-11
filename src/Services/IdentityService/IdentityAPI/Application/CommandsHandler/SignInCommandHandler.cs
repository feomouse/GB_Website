using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.CommandsHandler
{
  public class SignInCommandHandler : IRequestHandler<SignInCommand, bool>
  {
    IRepository _userRepo;

    public SignInCommandHandler (IRepository userRepo)
    {
      _userRepo = userRepo;  
    }

    public async Task<bool> Handle (SignInCommand command, CancellationToken cancellationToken)
    {
      var signInResult = _userRepo.PasswordSignInAsync(command.Email, command.Password).GetAwaiter().GetResult();
      
      if(signInResult.Succeeded) return true;
      else return false;
    }
  }
}