using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class DeleteShopTypeCommand : IRequest<int>
  {
    public string ShopTypeId {get; set; }

    public DeleteShopTypeCommand(string shopTypeId)
    {
      ShopTypeId = shopTypeId;
    }
  }
}