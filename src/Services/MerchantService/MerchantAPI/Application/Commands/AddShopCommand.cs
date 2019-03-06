using MediatR;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AddShopCommand : IRequest<int>
  {
    public MerchantBasic Basic;

    public string ShopId;

    public AddShopCommand(MerchantBasic basic, string shopId)
    {
      Basic = basic;
      ShopId = shopId;
    }
  }
}