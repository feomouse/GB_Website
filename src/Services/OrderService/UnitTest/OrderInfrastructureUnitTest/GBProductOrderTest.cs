using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;

namespace GB_Project.Services.OrderService.UnitTest.OrderInfrastructureUnitTest
{
  [TestClass]
  public class GBProductOrderTest
  {
    private BasicConfig config;

    public GBProductOrderTest()
    {
      config = new BasicConfig();
    }

    [TestMethod]
    public void TestAddGBOrder()
    {
      var order = new GroupBuyingOrder("苹果", 1, 23, false, "", false,
                              Guid.NewGuid(), 1, Guid.NewGuid(), "午后咖啡", DateTime.Now, "d/");

      int result = config.repository.AddGBOrder(order);

      Assert.AreNotEqual(0, result);
    }

    [TestMethod]
    public void TestGetGBOrders()
    {
      var orders = config.repository.GetGBOrders("D32CDB62-9F5C-44CD-1D9A-08D6ADE60FEF");

      Assert.AreEqual(1, orders.Count);
    }

    [TestMethod]
    public void TestSetGBOrderPayed()
    {
      var result = config.repository.SetGBOrderPayed("B85E76B8-C7E0-42E2-9200-145CE0ED4362");
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void TestSetGBOrderUsed()
    {        
      var resultFail = config.repository.SetGBOrderUsed("小鸡店", "B73E51EB-C162-415C-86D3-169849F62345");
      Assert.AreEqual(0, resultFail);

      var resultSuccess = config.repository.SetGBOrderUsed("小鸡店", "C4E2A996-BB9D-4145-9433-94AAFE3BCAE6");
      Assert.AreNotEqual(0, resultSuccess);
    }

    [TestMethod]
    public void TestSetGBOrderComment()
    {
      var result = config.repository.SetGBOrderComment("D8B01627-C983-43D3-883D-E76543C34539", "71F6E746-26AA-46BD-8BE4-456238127A01");

      Assert.AreNotEqual(0, result);
    }
  }
}