using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.UnitTest.ShopInfrastructureUnitTest
{
    [TestClass]
    public class ShopProductUnitTest
    {
        private BasicConfig config;

        public ShopProductUnitTest()
        {
            config = new BasicConfig(); 
        }

        /// <summary>
        /// 添加产品到指定的门店
        /// </summary>
        [TestMethod]
        public void TestAddShopProduct()
        {
          var listTypes = config.Repository.GetShopProductTypesByShopName("方格面包铺");
          var product = new Product( "牛肉米线", listTypes[0],"d/imgs/ricenood", 
                      13, 0, 0, true);

          var result = config.Repository.AddShopProduct(product);

          Assert.IsNotNull(result);
          Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestGetShopProductsByShopName()
        {
            var products = config.Repository.GetShopProductsByShopName("方格面包铺");

            Assert.AreEqual(5, products.Count);
        }
    }
}
