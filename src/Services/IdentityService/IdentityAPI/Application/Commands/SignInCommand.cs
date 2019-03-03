using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;
using MediatR;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.Commands
{
  public class SignInCommand : IRequest<bool>
  {
    public AppUser User { get; set; }

    public string Password { get; set; }

    public SignInCommand (AppUser user, string password)
    {
      User = user;
      Password = password;
    }
  }
}