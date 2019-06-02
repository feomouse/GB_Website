using System.Threading.Tasks;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.EventHandlers
{
  public class MerchantIsIdentitiedIntergrationEventHandler : IIntergrationEventHandler<MerchantIsIdentitiedIntergrationEvent>
  {
    public IShopRepository _repo;
    public MerchantIsIdentitiedIntergrationEventHandler(IShopRepository repo)
    {
      _repo = repo;      
    }

    public Task Handle(MerchantIsIdentitiedIntergrationEvent @eventName)
    {
      return Task.FromResult(_repo.IdentityMerchantOfShop(@eventName.Id.ToString(), @eventName.ShopId.ToString(), @eventName.IsIdentitied));
    }
  }
}