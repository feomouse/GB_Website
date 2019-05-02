using System.Threading.Tasks;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.EventHandlers
{
  public class IncreOrderSellIntergrationEventHandler : IIntergrationEventHandler<IncreOrderSellIntergrationEvent>
  {
    public IShopRepository _repo;
    public IncreOrderSellIntergrationEventHandler(IShopRepository repo)
    {
      _repo = repo;      
    }

    public Task Handle(IncreOrderSellIntergrationEvent @eventName)
    {
      return Task.FromResult(_repo.IncreGBPayAmount(@eventName.GBProductName, @eventName.ShopName, @eventName.ItemCost, @eventName.Number));
    }
  }
}