using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Application.Commands
{
  public class SetAddressCommand :IRequest<int>
  {
    public User _user { get; set; }

    public string Address { get; set; }

    public SetAddressCommand(User user, string address)
    {
      _user = user;
      Address = address;
    }
  }
}