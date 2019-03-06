using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Application.Commands
{
  public class SetImgCommand : IRequest<int>
  {
    public User User { get; set; }
    public string ImgLocation { get; set; }

    public SetImgCommand(User user, string imgLocation)
    {
      User = user;
      ImgLocation = imgLocation;
    }
  }
}