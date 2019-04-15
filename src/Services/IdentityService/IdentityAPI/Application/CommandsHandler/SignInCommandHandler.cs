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

    public Task<bool> Handle (SignInCommand command, CancellationToken cancellationToken)
    {
      if(command.Email == "")
      {
        return Task.FromResult(_userRepo.CheckPasswordSignInAsync(command.PhoneNumber, command.Password).GetAwaiter().GetResult().Succeeded);
      } else if(command.PhoneNumber == "") 
      {
        return Task.FromResult(_userRepo.CheckPasswordSignInAsync(command.Email, command.Password).GetAwaiter().GetResult().Succeeded);
      }
      else return Task.FromResult(false);
    }
  }
}