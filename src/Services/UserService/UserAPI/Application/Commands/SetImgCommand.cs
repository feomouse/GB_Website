using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Application.Commands
{
  public class SetImgCommand : IRequest<string>
  {
    public User User { get; set; }
    public string FileName { get; set; }

    public byte[] ImgData { get; set; }

    public SetImgCommand(User user, string fileName, byte[] imgData)
    {
      User = user;
      FileName = fileName;
      ImgData = imgData;
    }
  }
}