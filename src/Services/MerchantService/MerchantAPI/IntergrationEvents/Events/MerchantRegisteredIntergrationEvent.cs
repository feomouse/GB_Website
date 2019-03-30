using System;
using GB_Project.EventBus.BasicEventBus;

namespace GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.Events
{
    public class MerchantRegisteredIntergrationEvent : IntergrationEvent
    {
      public MerchantRegisteredIntergrationEvent(Guid merchantId) : base(merchantId, DateTime.UtcNow)
      {
      }
    }
}