using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Collections.Generic;
using System.Text;

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
            var shop = config.Repository.GetShopByName("jkk面包铺");
            Assert.IsNotNull(shop);
            Assert.AreEqual("jkk面包铺", shop.Name);
        }

        [TestMethod]
        public void TestGetShopListByShopType()
        {
            var shopList = config.Repository.GetShopListByShopType(1);

            Assert.AreNotEqual(0, shopList.Count);
            Assert.AreEqual(3, shopList.Count);
        }

        [TestMethod]
        public void TestCheckIfIdentitied()
        {
            var result = config.Repository.CheckIfIdentitied("BBA600CA-71C7-4DAD-3AD5-08D6A783F614");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestGetShopByMerchantId()
        {
            var shop = config.Repository.GetShopByMerchantId("E6DC7A9D-2873-45C5-8A78-E47ACBB0CE8E");

            Assert.IsNotNull(shop);
            Assert.AreEqual("E6DC7A9D-2873-45C5-8A78-E47ACBB0CE8E", shop.RegisterId.ToString(), true);
        }

        [TestMethod]
        public void TestIdentityMerchantOfShop()
        {
            var result = config.Repository.IdentityMerchantOfShop("81C58897-173B-4B66-6CF0-08D6A91AA29F", false);
        
            Assert.AreNotEqual(0 ,result);
        }

        [TestMethod]
        public void TestUploadShopImg()
        {
            var shop = config.Repository.GetShopByName("DDD");
            var result = config.Repository.UploadShopImg(shop, "testimg.test", Encoding.Default.GetBytes("efrre"));

            Assert.AreNotEqual("", result);
        }

        [TestMethod]
        public void TestSetGB()
        {
            int result = config.Repository.SetGB("B94EC18C-B604-4966-EFD7-08D6B3E894DA");

            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestGetShopByShopId()
        {
            var shop = config.Repository.GetShopByShopId("B94EC18C-B604-4966-EFD7-08D6B3E894DA");

            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void TestUpdateShop()
        {
            Shop newshop = new Shop("vf行车铺", "广东", "汕头", "金平区", "实时花园4栋222", 1, "13076384872", 
                     new Guid("D32CDB62-9F5C-44CD-1D9A-08D6ADE60FEF"), "/d/pic");
            newshop.SetPkId(new Guid("5CB54DB9-E4DC-448F-A4F7-08D6B4ED8369"));
            
            Shop getNewShop = config.Repository.UpdateShop(newshop);

            Assert.AreEqual("广东", getNewShop.Province);
        }
/* 
        [TestMethod]
        public void TestGetShopByShopId()
        {
            Shop shop = config.Repository.GetShopByShopId("C4CAA33A-BA64-42EC-20DE-08D69CA4202D");

            Assert.IsNotNull(shop);
            Assert.AreEqual("C4CAA33A-BA64-42EC-20DE-08D69CA4202D", shop.PkId.ToString(), true);
        } */

/*         [TestMethod]
        public void TestGetShops()
        {
            List<Shop> shops = config.Repository.GetShops();
        
            Assert.AreNotEqual(0, shops.Count);
            Assert.AreEqual("xx面包铺", shops[3].Name);
        } */
    }
}
