using MediatR;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;

namespace GB_Project.Services.UserService.UserAPI.Application.Commands
{
  public class SetImgCommand : IRequest<string>
  {
    public string UserId { get; set; }
    public string FileName { get; set; }


    public SetImgCommand(string userId, string fileName)
    {
      UserId = userId;
      FileName = fileName;
    }
  }
}