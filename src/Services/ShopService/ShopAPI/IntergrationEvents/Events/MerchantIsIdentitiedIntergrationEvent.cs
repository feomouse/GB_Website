using GB_Project.EventBus.BasicEventBus;
using System;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events
{
  public class MerchantIsIdentitiedIntergrationEvent : IntergrationEvent
  {
    public bool IsIdentitied { get; set; }

    public MerchantIsIdentitiedIntergrationEvent(Guid merchantId, bool checkResult) : base(merchantId, DateTime.Now)
    {
      IsIdentitied = checkResult;
    }
  }
}