using System;
using GB_Project.EventBus.BasicEventBus;

namespace GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events
{
  public class IncreOrderSellIntergrationEvent : IntergrationEvent
  {
    public string GBProductName { get; set; }

    public string ShopName { get; set; }

    public int ItemCost { get; set; }
    
    public IncreOrderSellIntergrationEvent(string gbProductName, string shopName, int itemCost) : base(Guid.NewGuid(), DateTime.Now)
    {
      GBProductName = gbProductName;
      ShopName = shopName;
      ItemCost = itemCost;
    }
  }
}