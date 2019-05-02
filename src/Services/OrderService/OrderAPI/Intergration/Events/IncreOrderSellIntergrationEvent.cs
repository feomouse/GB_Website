using System;
using GB_Project.EventBus.BasicEventBus;

namespace GB_Project.Services.OrderService.OrderAPI.Intergration.Events
{
  public class IncreOrderSellIntergrationEvent : IntergrationEvent
  {
    public string GBProductName { get; set; }

    public string ShopName { get; set; }

    public int ItemCost { get; set; }

    public int Number { get; set; }
    
    public IncreOrderSellIntergrationEvent(string gbProductName, string shopName, int itemCost, int num) : base(Guid.NewGuid(), DateTime.Now)
    {
      GBProductName = gbProductName;
      ShopName = shopName;
      ItemCost = itemCost;
      Number = num;
    }
  }
}