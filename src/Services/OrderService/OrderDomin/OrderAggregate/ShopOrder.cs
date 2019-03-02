using System;
using GB_Project.Services.OrderService.OrderDomin.SeedWork;

namespace GB_Project.Services.OrderService.OrderDomin.OrderAggregate
{
    public class ShopOrder : Entity
    {
      public Guid PkId { get; private set; }

      public bool IsProcessed { get; private set; }

      public bool IsAccepted { get; private set; }

      public Guid SpkId { get; private set; }

      public DateTime Time { get; private set; }

      public Guid BasicOrderId { get; private set; }
      public OrderBasic BasicOrder { get; private set; }

      public ShopOrder (bool isProcessed, bool isAccepted, Guid spkId, DateTime time)
      {
        IsProcessed = isProcessed;
        IsAccepted = isAccepted;
        SpkId = spkId;
        Time = time;
      }

      public void SetIsProcessed(bool isProcessed)
      {
        IsProcessed = isProcessed;
      }

      public void SetIsAccepted(bool isAccepted)
      {
        IsAccepted = isAccepted;
      }

      public void SetBasicOrder(OrderBasic order)
      {
        BasicOrder = order;
      }
    }
}