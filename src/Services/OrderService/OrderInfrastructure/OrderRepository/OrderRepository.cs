using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using GB_Project.Services.OrderService.OrderInfrastructure.Context;

namespace GB_Project.Services.OrderService.OrderInfrastructure.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
           _context = context;
        }

        public int AddBasicOrder (OrderBasic order)
        {
          var mid = _context.ordersBasic;
 
          if(mid != null)
          {
            mid.Add(order);
            
            return _context.SaveChanges();
          }

          else return 0;
        }

        public int AddCustomerOrder (CustomerOrder order)
        {
          _context.customerOrders.Add(order);

          return _context.SaveChanges();
        }

        public int AddShopOrder (ShopOrder order)
        {
          _context.shopOrders.Add(order);

          return _context.SaveChanges();
        }

        public int AddOrderProducts (List<OrderProduct> products)
        {
           _context.ordersProducts.AddRange(products);

          return _context.SaveChanges();
        }

        public List<CustomerOrder> GetCustomerOrdersByCustomerId (Guid customerPkId)
        {
          return _context.customerOrders.
                          Where(o => o.CpkId == customerPkId).
                          ToList();
        }

        public CustomerOrder GetCustomerOrderByCustomerOrderId (Guid customerOrderId)
        {
          return _context.customerOrders.
                          Where(o => o.PkId == customerOrderId).
                          First();
        }

        public OrderBasic GetOrderBasicByCustomerOrder (CustomerOrder customerOrder)
        {
          return _context.ordersBasic.
                          Where(o => o.PkId == customerOrder.BasicOrderId).
                          First<OrderBasic>();
        }

        public List<ShopOrder> GetShopOrdersByShopId (Guid shopPkId)
        {
          return _context.shopOrders.
                          Where(o => o.SpkId == shopPkId).
                          ToList();
        }

        public ShopOrder GetShopOrderByShopOrderId (Guid shopOrderId)
        {
          return _context.shopOrders.
                          Where(o => o.PkId == shopOrderId).
                          First();
        }

        public OrderBasic GetOrderBasicByShopOrder (ShopOrder shopOrder)
        {  
          return _context.ordersBasic.
                          Where(o => o.PkId == shopOrder.BasicOrderId).
                          First<OrderBasic>();
        }

        public List<OrderBasic> GetOrderBasicByAddress (string address)
        {
          return _context.ordersBasic.Where(o => o.Address == address).ToList();
        }

        public int SetShopOrderDecision (ShopOrder shopOrder, bool isAccept )
        {
          shopOrder.SetIsProcessed(true);
          shopOrder.SetIsAccepted(isAccept);

          return _context.SaveChanges();
        }
    }
}