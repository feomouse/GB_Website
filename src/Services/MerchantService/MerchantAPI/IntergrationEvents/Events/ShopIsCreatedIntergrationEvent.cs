using GB_Project.EventBus.BasicEventBus;
using System;

namespace GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.Events
{
  public class ShopIsCreatedIntergrationEvent : IntergrationEvent
  {
    public Guid MerchantId { get; private set; }

    public ShopIsCreatedIntergrationEvent(Guid shopId, Guid merchantId) : base(shopId, DateTime.Now)
    {
      MerchantId = merchantId;
    }
  }
}