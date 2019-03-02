using System;
using GB_Project.Services.OrderService.OrderDomin.SeedWork;

namespace GB_Project.Services.OrderService.OrderDomin.OrderAggregate
{
    public class OrderProduct
    {
      public Guid PpkId { get; private set; }

      public Guid SpkId { get; private set; }

      public Guid OpkId { get; private set; }
      public OrderBasic BasicOrder { get; private set; }

      public OrderProduct ( Guid ppkId, Guid spkId)
      {
        PpkId = ppkId;
        SpkId = spkId;
      }

      public void SetBasicOrder(OrderBasic basicOrder)
      {
        BasicOrder = basicOrder;
      }

      public void SetOPkId(Guid id)
      {
        OpkId = id;
      }
    }
}