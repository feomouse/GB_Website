using System;
using System.Collections.Generic;

namespace GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate
{
    public interface IGBOrderRepository
    {
        int AddGBOrder (GroupBuyingOrder order);

        List<GroupBuyingOrder> GetGBOrders (string UserId);

        GroupBuyingOrder GetGBOrderById (string orderId);

        int SetGBOrderPayed (string orderId);

        int SetGBOrderUsed (string shopName, string orderCode);

        int SetGBOrderComment (string orderId, string commentId);
    }
}