using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Collections.Generic;

namespace GB_Project.Services.ShopService.UnitTest.ShopInfrastructureUnitTest
{
    [TestClass]
    public class ShopGBProductUnitTest
    {
        private BasicConfig config;

        public ShopGBProductUnitTest()
        {
            config = new BasicConfig(); 
        }

        /// <summary>
        /// 添加产品到指定的门店
        /// </summary>
        [TestMethod]
        public void TestAddGBProduct()
        {
          var type = config.Repository.GetProductTypeByProductTypeId("D9E8A126-951E-47AF-FD1A-08D6CB9F4363");
          var gbProduct = new GBProduct("三角面包", 10, 8, "一个/份", DateTime.Now, DateTime.Now.AddDays(2), "1个月", "d/img", "无", type);
          var result = config.Repository.AddGBProduct(gbProduct);

          Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestGetGBProductsByShopName()
        {
            List<GBProduct> gbProducts = config.Repository.GetGBProductsByShopName("士多店", "天津市", "市辖区");
            
            Assert.AreNotEqual(0, gbProducts.Count);
        }

        [TestMethod]
        public void TestUpdateGBProducts()
        {
            ProductType pt = config.Repository.GetProductTypeByProductTypeId("E5768FBF-DF3C-403E-0739-08D6B4ED9D70");
            string sdate = "2019-05-06";
            string edate = "2019-05-06";

            GBProduct newp = config.Repository.UpdateGBProducts(new GBProduct(new Guid("B0FB1131-A29C-406D-A357-08D6B4EDC5EB"), "面条", 5, 2, "1个", Convert.ToDateTime(sdate), 
                                                             Convert.ToDateTime(sdate), "1年", "d/omg", "无", pt));
     
            Assert.AreEqual(5, newp.OrinPrice);
        }

        [TestMethod]
        public void TestDeleteGBProduct()
        {
            int result = config.Repository.DeleteGBProduct("苹果");
        
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestGetGBProductKeyByName()
        {
            string result = config.Repository.GetGBProductKeyByName("咖啡");

            Assert.AreNotEqual("", result);
        }

        [TestMethod]
        public void TestGetGBProductsByProductId()
        {
            var result = config.Repository.GetGBProductsByProductId("87813CBD-895D-42F5-E6BC-08D6C0ADD1A4");
            Assert.AreEqual(2, result.Count);

        }
/* 
        [TestMethod]
        public void TestGetShopProductsByShopName()
        {
            var products = config.Repository.GetShopProductsByShopName("方格面包铺");

            Assert.AreEqual(5, products.Count);
        } */
    }
}
