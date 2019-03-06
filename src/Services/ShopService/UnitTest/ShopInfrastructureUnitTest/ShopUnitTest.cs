using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Collections.Generic;

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
            Shop newShop = new Shop("jkk面包铺", "广东", "揭阳", "金平区", 
                                    "易初莲花金平店二楼4号", 1, "13045123543", Guid.NewGuid(), "d/pic/mshop.jpeg");
         
            var result = config.Repository.CreateShop(newShop);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result);
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

        [TestMethod]
        public void TestGetShopByShopId()
        {
            Shop shop = config.Repository.GetShopByShopId("C4CAA33A-BA64-42EC-20DE-08D69CA4202D");

            Assert.IsNotNull(shop);
            Assert.AreEqual("C4CAA33A-BA64-42EC-20DE-08D69CA4202D", shop.PkId.ToString(), true);
        }

        [TestMethod]
        public void TestGetShops()
        {
            List<Shop> shops = config.Repository.GetShops();
        
            Assert.AreNotEqual(0, shops.Count);
            Assert.AreEqual("xx面包铺", shops[3].Name);
        }
    }
}
