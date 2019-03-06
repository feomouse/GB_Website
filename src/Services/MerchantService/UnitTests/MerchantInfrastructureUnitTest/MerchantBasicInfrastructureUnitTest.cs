using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;

namespace GB_Project.Services.MerchantService.UnitTests.MerchantInfrastructureUnitTest
{
  [TestClass]
  public class MerchantBasicInfrastructureUnitTest
  {
    private BasicConfig config;

    public MerchantBasicInfrastructureUnitTest()
    {
      config = new BasicConfig();
    }

    /// <summary>
    /// 创建商户基础信息
    /// </summary>
    [TestMethod]
    public void TestCreateMerchantBasic()
    {
      var merchantBasic = new MerchantBasic(Guid.NewGuid());
      int result = config.Repository.CreateMerchantBasic(merchantBasic).GetAwaiter().GetResult();
      Assert.AreNotEqual(0, result);
    }

    /// <summary>
    /// 商户绑定门店主键
    /// </summary>
    [TestMethod]
    public void TestAddShopIdToMerchant()
    {
      var merchantBasic = config.Repository.GetMerhcntBasicByMerchantId("1691A5D2-0687-403C-9CDC-08D69679A372");

      int result = config.Repository.AddShopIdToMerchant(merchantBasic, Guid.NewGuid()).GetAwaiter().GetResult();

      Assert.AreNotEqual(0, result);
      Assert.AreEqual(1, result);
    }
 
    /// <summary>
    /// 根据商户主键得到商户的basic实体
    /// </summary>
    [TestMethod]
    public void TestGetMerhcntBasicByMerchantId()
    {
      var merchantBasic = config.Repository.GetMerhcntBasicByMerchantId("1691A5D2-0687-403C-9CDC-08D69679A372");

      Assert.AreEqual("1691A5D2-0687-403C-9CDC-08D69679A372", merchantBasic.AuthPkId.ToString(), true);
    } 
  }
}