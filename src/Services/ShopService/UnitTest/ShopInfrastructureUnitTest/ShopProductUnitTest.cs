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
          var listTypes = config.Repository.GetShopProductTypesByShopId(new Guid("C4CAA33A-BA64-42EC-20DE-08D69CA4202D"));
          var product = new Product( "牛肉面", listTypes[0],"d/imgs/noodles", 
                      13, 0, 0, true);

          var productGuid = config.Repository.AddShopProduct(product);

          Assert.IsNotNull(productGuid);
          Assert.IsInstanceOfType(productGuid, typeof(Guid));
          
        }
    }
}
