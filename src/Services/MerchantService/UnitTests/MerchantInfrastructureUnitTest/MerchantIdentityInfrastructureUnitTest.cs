using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;

namespace GB_Project.Services.MerchantService.UnitTests.MerchantInfrastructureUnitTest
{
  [TestClass]
  public class MerchantIdentityInfrastructureUnitTest
  {
    private BasicConfig config;

    public MerchantIdentityInfrastructureUnitTest()
    {
      config = new BasicConfig();
    }


    /// <summary>
    /// 添加merchantIdentity实体
    /// </summary>
    [TestMethod]
    public void TestAddIdentity()
    {
      var merchantBasic = config.Repository.GetMerhcntBasicByMerchantId("1691A5D2-0687-403C-9CDC-08D69679A372");
      var merchantIdentity = new MerchantIdentity("老吴", "440507199607030615", "/d/imgs/f/f.jpg", "/d/imgs/b/b.jpg", "/d/imgs/l/l.jpg", 
                          "1111111111111", "小小食品有限公司", "吴斐", DateTime.Now, 
                          DateTime.Now.AddMonths(10), "13076384872");

      int result = config.Repository.AddIdentity(merchantBasic, merchantIdentity).GetAwaiter().GetResult();

      Assert.AreNotEqual(0, result);
    }

    [TestMethod]
    public void TestAddIdentityIdToMerchant()
    {
      var merchantBasic = config.Repository.GetMerhcntBasicByMerchantId("0848521A-588B-47CA-5A31-08D696F6C1BC");

      var merchantIdentity = new MerchantIdentity("老trr", "440657199606530615", "/d/imgs/f/x.jpg", "/d/imgs/b/b.jpg", "/d/imgs/l/l.jpg", 
                          "1111111145541", "ddfj食品有限公司", "老trr", DateTime.Now, 
                          DateTime.Now.AddMonths(10), "1307636572");
      int result = config.Repository.AddIdentity(merchantBasic, merchantIdentity).GetAwaiter().GetResult();
      
      Assert.AreNotEqual(0, result);

      int resultAdd = config.Repository.AddIdentityIdToMerchant(merchantBasic, merchantIdentity).GetAwaiter().GetResult();
      Assert.AreNotEqual(0, resultAdd);
    }
  }
}