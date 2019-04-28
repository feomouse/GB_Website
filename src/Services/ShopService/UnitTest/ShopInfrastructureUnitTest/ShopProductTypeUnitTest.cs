using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Collections.Generic;

namespace GB_Project.Services.ShopService.UnitTest.ShopInfrastructureUnitTest
{
  [TestClass]
  public class ShopProductTypeUnitTest
  {
      BasicConfig config;

      public ShopProductTypeUnitTest()
      {
        config = new BasicConfig();
      }

      /// <summary>
      /// 创建门店产品类型
      /// </summary>
      [TestMethod]
      public void TestCreateShopProductType()
      {
        var shop = config.Repository.GetShopByNameAndCity("士多店", "天津市", "市辖区");
        
        var productType = new ProductType(shop, "凉菜");
        var result = config.Repository.CreateShopProductType(productType);

        Assert.AreNotEqual(0, result);
        Assert.IsNotNull(result);
      }

      [TestMethod]
      public void TestGetProductTypeByProductTypeId()
      {
        var type = config.Repository.GetProductTypeByProductTypeId("67C6CC2F-043F-4C51-437B-08D6B469234C");

        Assert.IsNotNull(type);
      }

      [TestMethod]
      public void TestGetShopProductTypesByShopName()
      {
        var types = config.Repository.GetShopProductTypesByShopName("士多店", "天津市", "市辖区");

        Assert.AreNotEqual(0, types.Count);
      }

      [TestMethod]
      public void TestDeleteProductType()
      {
        var result = config.Repository.DeleteProductType("903F81D3-C01F-4F0D-0738-08D6B4ED9D70");
        Assert.AreNotEqual(0, result);
      }

/*       [TestMethod]
      public void TestGetShopProductTypesByShopName()
      {
        List<ProductType> types = config.Repository.GetShopProductTypesByShopName("方格面包铺");
      
        Assert.AreNotEqual(0, types.Count);
      } */
  }
}