using System;
using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Application.Commands
{
  public class SetUserNameCommand : IRequest<int>
  {
    public string UserId { get; set; }

    public string UserName { get; set; }

    public SetUserNameCommand (string userId, string userName)
    {
      UserId = userId;

      UserName = userName;
    }
  }
}