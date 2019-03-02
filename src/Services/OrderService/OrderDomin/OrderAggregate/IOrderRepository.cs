using System;
using System.Collections.Generic;

namespace GB_Project.Services.OrderService.OrderDomin.OrderAggregate
{
    public interface IOrderRepository
    {
        int AddBasicOrder (OrderBasic order);

        int AddCustomerOrder (CustomerOrder order);

        int AddShopOrder (ShopOrder order);

        int AddOrderProducts (List<OrderProduct> products);

        List<CustomerOrder> GetCustomerOrdersByCustomerId (Guid customerPkId);

        CustomerOrder GetCustomerOrderByCustomerOrderId (Guid customerOrderId);

        OrderBasic GetOrderBasicByCustomerOrder (CustomerOrder customerOrder);

        List<ShopOrder> GetShopOrdersByShopId (Guid shopPkId);

        OrderBasic GetOrderBasicByShopOrder (ShopOrder shopOrder);

        List<OrderBasic> GetOrderBasicByAddress (string address);

        int SetShopOrderDecision (ShopOrder shopOrder, bool isAccept );
    }
}