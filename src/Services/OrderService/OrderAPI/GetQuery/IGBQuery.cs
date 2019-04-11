using System.Collections.Generic;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;

namespace GB_Project.Services.OrderService.OrderAPI.GetQuery
{
  public interface IGBQuery
  {
      List<GroupBuyingOrder> getGBProductListByUserId(string userId);
  }
}