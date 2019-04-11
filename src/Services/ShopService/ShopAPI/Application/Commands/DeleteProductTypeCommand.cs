using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class DeleteProductTypeCommand : IRequest<int>
  {
    public string ProductTypePkId {get; set; }

    public DeleteProductTypeCommand(string productTypePkId)
    {
      ProductTypePkId = productTypePkId;
    }
  }
}