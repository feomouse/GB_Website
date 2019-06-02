using GB_Project.EventBus.BasicEventBus;
using System;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events
{
  public class MerchantIsIdentitiedIntergrationEvent : IntergrationEvent
  {
    public Guid MerchantId { get; set; }
    public Guid ShopId { get; set; }
    public bool IsIdentitied { get; set; }

    public MerchantIsIdentitiedIntergrationEvent(Guid merchantId, Guid shopId, bool checkResult) : base(merchantId, DateTime.Now)
    {
      MerchantId = merchantId;
      ShopId = shopId;
      IsIdentitied = checkResult;
    }
  }
}