using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class IncreaseVisitNumCommand : IRequest<int>
  {
    public string ShopId {get; set; }

    public string Year { get; set; }

    public string Month { get; set; }

    public IncreaseVisitNumCommand(string shopId, string year, string month)
    {
      ShopId = shopId;
      Year = year;
      Month = month;
    }
  }
}