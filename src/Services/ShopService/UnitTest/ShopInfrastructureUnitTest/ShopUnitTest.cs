using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.UnitTest.ShopInfrastructureUnitTest
{
    [TestClass]
    public class ShopUnitTest
    {
        private BasicConfig config;

        public ShopUnitTest()
        {
            config = new BasicConfig(); 
        }

        /// <summary>
        /// 创建门店
        /// </summary>
        [TestMethod]
        public void TestCreateShop()
        {
            Shop newShop = new Shop("方格面包铺", "广东", "汕头", "金平区", 
                                    "易初莲花金平店二楼4号", 1, "13045123543", Guid.NewGuid(), "d/pic/mshop.jpeg");
         
            var newShopGuid = config.Repository.CreateShop(newShop);
            Assert.IsNotNull(newShopGuid);
            Assert.IsInstanceOfType(newShopGuid, typeof(Guid));
        }

        /// <summary>
        /// 根据门店名称获取门店实体
        /// </summary>
        [TestMethod]
        public void TestGetShopByName()
        {
            var shop = config.Repository.GetShopByName("方格面包铺");
            Assert.IsNotNull(shop);
            Assert.AreEqual("方格面包铺", shop.Name);
        }
    }
}
