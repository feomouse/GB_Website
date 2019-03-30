using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using Microsoft.AspNetCore.Identity;
using GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.Events;

namespace GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.EventHandler
{
    public class ShopIsCreatedIntergrationEventHandler : IIntergrationEventHandler<ShopIsCreatedIntergrationEvent>
    {
      private IMerchantRepository _repository;

      public ShopIsCreatedIntergrationEventHandler(IMerchantRepository repository)
      {
        _repository = repository;
      }

      public async Task Handle(ShopIsCreatedIntergrationEvent @event)
      {
        var merchantBasic = _repository.GetMerhcntBasicByMerchantId(@event.MerchantId.ToString());

        await _repository.AddShopIdToMerchant(merchantBasic, @event.Id);
      }
    }
}