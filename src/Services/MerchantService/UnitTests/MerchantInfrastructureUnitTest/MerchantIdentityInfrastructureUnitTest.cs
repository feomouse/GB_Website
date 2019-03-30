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
      var merchantBasic = config.Repository.GetMerhcntBasicByMerchantId("6DF4A3FE-3CC7-44A5-8EEF-E2E97FB9C0D3");
      var merchantIdentity = new MerchantIdentity("老吴", "440507199607030615", "/d/imgs/f/f.jpg", "/d/imgs/b/b.jpg", "/d/imgs/l/l.jpg", 
                          "1111111111111", "小小食品有限公司", "吴斐", DateTime.Now, 
                          DateTime.Now.AddMonths(10), "13076384872");

      int result = config.Repository.AddIdentity(merchantBasic, merchantIdentity).GetAwaiter().GetResult();

      Assert.AreNotEqual(0, result);
    }
  }
}