using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Application.Commands
{
  public class SetAddressCommand :IRequest<int>
  {
    public string UserId { get; set; }

    public string Address { get; set; }

    public SetAddressCommand(string userId, string address)
    {
      UserId = userId;
      Address = address;
    }
  }
}