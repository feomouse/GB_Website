using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using System.Linq;

namespace GB_Project.Services.OrderService.UnitTest.OrderInfrastructureUnitTest
{
  [TestClass]
  public class ShopOrderUnitTest
  {
    BasicConfig config;

    public ShopOrderUnitTest()
    {
      config = new BasicConfig();
    }

    /// <summary>
    /// 添加商户方的订单数据
    /// </summary>
    [TestMethod]
    public void TestAddShopOrder()
    {
      ShopOrder shopOrder = new ShopOrder(false, false, Guid.NewGuid(), DateTime.Now);

      OrderBasic orderBasic = config.repository.GetOrderBasicByAddress("SomePlace in China").Last();

      shopOrder.SetBasicOrder(orderBasic);

      Assert.AreNotEqual(0, config.repository.AddShopOrder(shopOrder));
    }

    /// <summary>
    /// 根据门店主键获取门店全部订单
    /// </summary>
    [TestMethod]
    public void TestGetShopOrdersByShopId()
    {
      // guid from database existed data
      var shopOrders = config.repository.GetShopOrdersByShopId(new Guid("37877DE5-E5F7-40DE-8BC9-9D4AF47C5727"));

      Assert.AreNotEqual(0, shopOrders.Count);
      Assert.AreEqual(1, shopOrders.Count);
    }

    /// <summary>
    /// 根据门店订单主键获取门店订单
    /// </summary>
    [TestMethod]
    public void TestGetShopOrderByShopOrderId()
    {
      // guid from database existed data
      var shopOrder = config.repository.GetShopOrderByShopOrderId(new Guid("8CFD102E-8A6A-48C6-36E5-08D69A152C10"));

      Assert.IsNotNull(shopOrder);
    }

    /// <summary>
    /// 根据门店订单获取基础订单
    /// </summary>
    [TestMethod]
    public void TestGetOrderBasicByShopOrder()
    {
      // guid from database existed data
      var shopOrder = config.repository.GetShopOrderByShopOrderId(new Guid("8CFD102E-8A6A-48C6-36E5-08D69A152C10"));

      var basicOrder = config.repository.GetOrderBasicByShopOrder(shopOrder);

      Assert.IsNotNull(basicOrder);
    }

    /// <summary>
    /// 设置失手接单
    /// </summary>
    [TestMethod]
    public void TestSetShopOrderDecision()
    {
      // guid from database existed data
      var sOrder = config.repository.GetShopOrderByShopOrderId(new Guid("8CFD102E-8A6A-48C6-36E5-08D69A152C10"));

      Assert.AreNotEqual(0, config.repository.SetShopOrderDecision(sOrder, true));
    }
  }
}