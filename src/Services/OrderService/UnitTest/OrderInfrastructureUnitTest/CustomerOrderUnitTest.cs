using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GB_Project.Services.OrderService.UnitTest.OrderInfrastructureUnitTest
{
    [TestClass]
    public class CustomerOrderUnitTest
    {
      BasicConfig config;

      public CustomerOrderUnitTest()
      {
        config = new BasicConfig();
      }

      /// <summary>
      /// 添加客户订单
      /// </summary>
      [TestMethod]
      public void TestAddCustomerOrder()
      {
        OrderBasic order = config.repository.GetOrderBasicByAddress("SomePlace in China").First();

        CustomerOrder cOrder = new CustomerOrder(1, Guid.NewGuid(), DateTime.Now);
        cOrder.SetOrderBasic(order);

        Assert.AreNotEqual(0, config.repository.AddCustomerOrder(cOrder));
      }

      /// <summary>
      /// 根据客户主键获取其全部订单
      /// </summary>
      [TestMethod]
      public void TestGetCustomerOrdersByCustomerId()
      {
        Guid customerId = Guid.NewGuid();
        Guid shopId = Guid.NewGuid();

        var OPList = new List<OrderProduct>();

        for(int i = 0; i < 3; i++)
        {
            OPList.Add(new OrderProduct(Guid.NewGuid(), Guid.NewGuid()));
        }
        OrderBasic item1 = new OrderBasic(customerId, shopId, "nonono", "SomePlace in China", "SomeOne",
              200, new Guid(), true);
        OrderBasic item2 = new OrderBasic(customerId, shopId, "nonono", "SomePlace in China", "SomeOne",
              200, new Guid(), true);
        OrderBasic item3 = new OrderBasic(customerId, shopId, "nonono", "SomePlace in China", "SomeOne",
              200, new Guid(), true);

        OPList[0].SetBasicOrder(item1);
        OPList[1].SetBasicOrder(item2);
        OPList[2].SetBasicOrder(item3);
        
        config.repository.AddBasicOrder(item1);
        config.repository.AddBasicOrder(item2);
        config.repository.AddBasicOrder(item3);
        config.repository.AddOrderProducts(OPList);

        CustomerOrder cOrder1 = new CustomerOrder(1, customerId, DateTime.Now);
        CustomerOrder cOrder2 = new CustomerOrder(2, customerId, DateTime.Now);
        CustomerOrder cOrder3 = new CustomerOrder(1, customerId, DateTime.Now);

        cOrder1.SetOrderBasic(item1);
        cOrder2.SetOrderBasic(item2);
        cOrder3.SetOrderBasic(item3);

        config.repository.AddCustomerOrder(cOrder1);
        config.repository.AddCustomerOrder(cOrder2);
        config.repository.AddCustomerOrder(cOrder3);

        Assert.AreEqual(3, config.repository.GetCustomerOrdersByCustomerId(customerId).Count);
      }

      /// <summary>
      /// 根据顾客订单主键获取客户订单
      /// </summary>
      [TestMethod]
      public void TestGetCustomerOrderByCustomerOrderId()
      {
        var cOrder = config.repository.GetCustomerOrderByCustomerOrderId(new Guid("370925E2-3C77-4DF2-E044-08D69A1E2EA5"));

        Assert.IsNotNull(cOrder);
        Assert.IsInstanceOfType(cOrder, typeof(CustomerOrder));
      }
    }
}