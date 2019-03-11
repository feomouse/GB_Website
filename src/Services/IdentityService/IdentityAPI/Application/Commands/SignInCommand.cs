using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;
using MediatR;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.Commands
{
  public class SignInCommand : IRequest<bool>
  {
    public string Email { get; set; }

    public string Password { get; set; }

    public SignInCommand (string email, string password)
    {
      Email = email;
      Password = password;
    }
  }
}