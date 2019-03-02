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
        var shop = config.Repository.GetShopByName("方格面包铺");
        
        var productType = new ProductType(shop, "面食");
        var productTypeId = config.Repository.CreateShopProductType(productType);

        Assert.IsInstanceOfType(productTypeId, typeof(Guid));
        Assert.IsNotNull(productTypeId);
      }

      /// <summary>
      /// 根据门店主键获取门店全部产品类型
      /// </summary>
      [TestMethod]
      public void TestGetShopProductTypesByShopId()
      {
        List<ProductType> productTypes = config.Repository.GetShopProductTypesByShopId(new Guid("C4CAA33A-BA64-42EC-20DE-08D69CA4202D"));

        Assert.AreEqual("B66E9E8F-C80E-469C-7A62-08D69CA530DE", productTypes[0].PkId.ToString(), true);
      }
  }
}