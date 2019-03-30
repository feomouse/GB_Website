using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class SetGBCommand : IRequest<int>
  {
    public string ShopId {get; set; }
  }
}