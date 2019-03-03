using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;
using MediatR;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.Commands
{
  public class UpdateUserCommand : IRequest<IdentityResult>
  {
    public AppUser User { get; set; }

    public UpdateUserCommand (AppUser user)
    {
      User = user;
    }
  }
}