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
        var shop = config.Repository.GetShopByName("花园行车铺");
        
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

/*       [TestMethod]
      public void TestGetShopProductTypesByShopName()
      {
        List<ProductType> types = config.Repository.GetShopProductTypesByShopName("方格面包铺");
      
        Assert.AreNotEqual(0, types.Count);
      } */
  }
}