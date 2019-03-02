using GB_Project.Services.OrderService.OrderDomin.SeedWork;
using System;
using System.Collections.Generic;

namespace GB_Project.Services.OrderService.OrderDomin.OrderAggregate
{
    public class OrderBasic : Entity, AggregateRoot
    {
      public Guid PkId { get; private set; }  

      public Guid CustomerPkId { get; private set; }

      public Guid ShopPkId { get; private set; }

      public List<OrderProduct> OrderItems { get; private set; }

      public string Remark { get; private set; }

      public string Address { get; private set; }

      public string Sender { get; private set; }

      public int TotalCost { get; private set; }

      public Guid Evaluate { get; private set; }

      public bool IsFinished { get; private set; }

      public CustomerOrder COrder { get; private set; }

      public ShopOrder SOrder { get; private set; }

      public OrderBasic ( Guid customerPkId, Guid shopPkId, string remark, string address, string sender,
                          int totalCost, Guid evaluate, bool isFinished )
      {
/*         foreach ( Guid item in orderItems)
        {
          OrderItems.Add(item);
        } */
        CustomerPkId = customerPkId;
        ShopPkId = shopPkId;
        Remark = remark;
        Address = address;
        Sender = sender;
        TotalCost = totalCost;
        Evaluate = evaluate;
        IsFinished = isFinished;
      }
    }
}