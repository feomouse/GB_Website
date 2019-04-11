using System.Collections.Generic;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;

namespace GB_Project.Services.OrderService.OrderAPI.GetQuery
{
  public class GBQuery : IGBQuery
  {
    private IGBOrderRepository _repo;

    public GBQuery(IGBOrderRepository repo)
    {
      _repo = repo;
    }

    public List<GroupBuyingOrder> getGBProductListByUserId(string userId)
    {
      return _repo.GetGBOrders(userId);
    }
  }
}