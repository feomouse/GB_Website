using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class DeleteGBProductCommand : IRequest<int>
  {
    public string GBProductId {get; set; }

    public DeleteGBProductCommand(string id)
    {
      GBProductId = id;
    }
  }
}