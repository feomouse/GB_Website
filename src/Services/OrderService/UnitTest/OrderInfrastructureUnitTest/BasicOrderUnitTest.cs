using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.OrderService.OrderInfrastructure.OrderRepository;
using GB_Project.Services.OrderService.OrderDomin.OrderAggregate;
using GB_Project.Services.OrderService.OrderInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GB_Project.Services.OrderService.UnitTest.OrderInfrastructureUnitTest
{
    [TestClass]
    public class BasicOrderUnitTest
    {
        BasicConfig config;

        public BasicOrderUnitTest()
        {
            config = new BasicConfig();
        }

        /// <summary>
        /// 添加基础订单与订单的内容
        /// </summary>
        [TestMethod]
        public void TestAddBasicOrderAndOrderProduct()
        {
            OrderBasic item = new OrderBasic(new Guid(), new Guid(), "nonono", "SomePlace in China", "SomeOne",
                          200, new Guid(), true);

            Assert.AreNotEqual(0, config.repository.AddBasicOrder(item));

            OrderBasic order = config.repository.GetOrderBasicByAddress("SomePlace in China").First();

            var OPList = new List<OrderProduct>();

            for(int i = 0; i < 5; i++)
            {
                OPList.Add(new OrderProduct(Guid.NewGuid(), Guid.NewGuid()));
            }

            foreach (var i in OPList)
            {
                i.SetBasicOrder(order);
            }

            Assert.AreNotEqual(0, config.repository.AddOrderProducts(OPList));
        }

        /// <summary>
        /// 根据客户订单主键获取基础订单实体
        /// </summary>
        [TestMethod]
        public void TestGetOrderBasicByCustomerOrderId()
        {
            CustomerOrder cOrder = config.repository.GetCustomerOrderByCustomerOrderId(new Guid("370925E2-3C77-4DF2-E044-08D69A1E2EA5"));
            var basicOrder = config.repository.GetOrderBasicByCustomerOrder(cOrder);
            // guid是我从数据库里取的
           Assert.IsNotNull(basicOrder);
           Assert.IsInstanceOfType(basicOrder, typeof(OrderBasic));
        }

        /// <summary>
        /// 根据用户地址获取基础订单
        /// </summary>
        [TestMethod]
        public void TestGetOrderBasicByAddress()
        {
            var basicOrders = config.repository.GetOrderBasicByAddress("SomePlace in China");

            Assert.AreEqual(4, basicOrders.Count);
        }
    }
}
