using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class IncreaseMonthSellCommand : IRequest<int>
  {
    public string ShopId {get; set; }

    public string Year { get; set; }

    public string Month { get; set; }

    public IncreaseMonthSellCommand(string shopId, string year, string month)
    {
      ShopId = shopId;
      Year = year;
      Month = month;
    }
  }
}