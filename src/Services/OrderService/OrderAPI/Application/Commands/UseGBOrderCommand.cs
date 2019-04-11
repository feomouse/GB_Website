using MediatR;

namespace GB_Project.Services.OrderService.OrderAPI.Application.Commands
{
  public class UseGBOrderCommand : IRequest<int>
  {
    public string ShopName { get; private set; }

    public string OrderCode { get; private set; }

    public UseGBOrderCommand(string shopName, string orderCode)
    {
      ShopName = shopName;
      OrderCode = orderCode;
    }
  }
}