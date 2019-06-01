using GB_Project.EventBus.BasicEventBus;
using System;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events
{
  public class BindShopIntergrationEvent : IntergrationEvent
  {
    public Guid MerchantId { get; set; }

    public Guid ShopId { get; set; }

    public BindShopIntergrationEvent(Guid merchantId, Guid shopId) : base(merchantId, DateTime.Now)
    {
      MerchantId = merchantId;
      
      ShopId = shopId;
    }
  }
}