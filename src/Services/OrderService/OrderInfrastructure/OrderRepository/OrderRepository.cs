using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using GB_Project.Services.OrderService.OrderInfrastructure.Context;

namespace GB_Project.Services.OrderService.OrderInfrastructure.OrderRepository
{
    public class OrderRepository : IGBOrderRepository
    {
        OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
           _context = context;
        }

        public int AddGBOrder (GroupBuyingOrder order)
        {
          _context.GroupBuyingOrders.Add(order);

          return _context.SaveChanges();
        }

        public List<GroupBuyingOrder> GetGBOrders (string UserId)
        {
          return _context.GroupBuyingOrders.Where(b => b.CpkId.ToString() == UserId).ToList();
        }

        public int SetGBOrderPayed (string orderId)
        {
          var order = _context.GroupBuyingOrders.Where(b => b.PkId.ToString() == orderId).FirstOrDefault();

          order.SetIsPayed();

          return _context.SaveChanges();
        }

        public int SetGBOrderUsed (string shopName, string orderCode)
        {
          var orders = _context.GroupBuyingOrders.Where(b => b.SName == shopName).ToList();

          if(orders.Count == 0) return 0;

          foreach(var i in orders)
          {
            if(i.OrderCode.ToString() == orderCode.ToLower())
            {
              i.SetIsUsed();
              return _context.SaveChanges();
            }
          }

          return 0;
        }

        public int SetGBOrderComment (string orderId, string commentId)
        {
          var order = _context.GroupBuyingOrders.Where(b => b.PkId.ToString() == orderId).FirstOrDefault();

          if(order == null) return 0;

          order.SetCommentId(commentId);

          return _context.SaveChanges();
        }
    }
}