using MediatR;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AddShopCommand : IRequest<int>
  {
    public string MerchantId { get; set; }

    public string ShopId { get; set; }

    public AddShopCommand(string merchantId, string shopId)
    {
      MerchantId = merchantId;
      ShopId = shopId;
    }
  }
}