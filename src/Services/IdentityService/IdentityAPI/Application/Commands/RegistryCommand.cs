using MediatR;
using Microsoft.AspNetCore.Identity;
using System;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.Commands
{
  public class RegistryCommand : IRequest<string>
  {
    public string Email { get; set;}

    public string Password { get; set;}

    public string Role { get; set; }

    public RegistryCommand ()
    {
      
    }

    public RegistryCommand(string email, string password, string role)
    {
      Email = email;
      Password = password;
      Role = role;
    }
  }
}