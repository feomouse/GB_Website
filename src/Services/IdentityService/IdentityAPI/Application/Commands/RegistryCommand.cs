using MediatR;
using Microsoft.AspNetCore.Identity;
using System;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.Commands
{
  public class RegistryCommand : IRequest<string>
  {
    public string Email { get; set;}

    public string PhoneNumber { get; set; }

    public string Password { get; set;}

     public string ConfirmedPassword { get; set;}

     public string Role { get; set; }

    public RegistryCommand ()
    {
      
    }

    public RegistryCommand(string email, string phoneNumber, string password, string confirmedPassword ,string role)
    {
      Email = email;
      PhoneNumber = phoneNumber;
      Password = password;
      ConfirmedPassword = confirmedPassword;
      Role = role;
    }
  }
}