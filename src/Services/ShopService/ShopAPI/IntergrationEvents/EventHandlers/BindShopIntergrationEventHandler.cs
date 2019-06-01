using System.Threading.Tasks;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.EventHandlers
{
  public class BindShopIntergrationEventHandler : IIntergrationEventHandler<BindShopIntergrationEvent>
  {
    public IShopRepository _repo;
    public BindShopIntergrationEventHandler(IShopRepository repo)
    {
      _repo = repo;      
    }

    public Task Handle(BindShopIntergrationEvent @eventName)
    {
      return Task.FromResult(_repo.SetMerchantToShop(@eventName.ShopId, @eventName.MerchantId));
    }
  }
}