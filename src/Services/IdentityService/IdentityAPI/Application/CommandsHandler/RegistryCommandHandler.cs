using System.Threading;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Threading.Tasks;
using System;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.CommandsHandler
{
  public class RegistryCommandHandler : IRequestHandler<RegistryCommand, string>
  {
    IUserStore<AppUser> UserRepo;

    IUserRoleStore<AppUser> UserRoleRepo;

    IRoleStore<AppRole> RoleRepo; 

    public RegistryCommandHandler(IUserStore<AppUser> userRepo, 
                                  IUserRoleStore<AppUser> userRoleRepo, 
                                  IRoleStore<AppRole> roleRepo)
    {
      UserRepo = userRepo;
      UserRoleRepo = userRoleRepo;
      RoleRepo = roleRepo;
    }
    public async Task<string> Handle(RegistryCommand command, CancellationToken cancellation)
    {
      var user = new AppUser(command.Email, command.PhoneNumber);

      user.SetHashPassword(command.Password);

      IdentityResult createResult = await UserRepo.CreateAsync(user, default(CancellationToken));
      
      if(!createResult.Succeeded)
      {
        return "";
      }

      UserRoleRepo.AddToRoleAsync(user,command.Role, default(CancellationToken)).GetAwaiter().GetResult();

      if(UserRoleRepo.IsInRoleAsync(user, command.Role, default(CancellationToken)).GetAwaiter().GetResult())
      {
        return UserRepo.GetUserIdAsync(user, default(CancellationToken)).GetAwaiter().GetResult().ToString();
      }

      else return "";
    }
  }
}