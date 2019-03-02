using System;
using GB_Project.Services.OrderService.OrderDomin.SeedWork;

namespace GB_Project.Services.OrderService.OrderDomin.OrderAggregate
{
    public class CustomerOrder : Entity
    {
      public Guid PkId { get; private set; }

      public int PayWay { get; private set; }

      public Guid CpkId { get; private set; }

      public DateTime Time { get; private set; }

      public Guid BasicOrderId { get; private set; }
      public OrderBasic BasicOrder { get; private set; }

      public CustomerOrder (int payWay, Guid cpkId,
                            DateTime time)
      {
        PayWay = payWay;
        CpkId = cpkId;
        Time = time;
      }

      public void SetOrderBasic(OrderBasic basicOrder)
      {
        BasicOrder = basicOrder;
      }
    }
}