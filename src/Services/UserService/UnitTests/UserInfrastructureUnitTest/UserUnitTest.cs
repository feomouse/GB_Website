using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GB_Project.Services.UserService.UnitTests.UserInfrastructureUnitTest
{
  [TestClass]
  public class UserUnitTest
  {
    private BasicConfig config;

    public UserUnitTest()
    {
      config = new BasicConfig();
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    [TestMethod]
    public void TestCreateUser()
    {
      User user = new User("/d/imgs/dd.jpge", "广东省广州市天河区新偶像3号");
      int result = config.Repository.CreateUser(user);

      Assert.AreNotEqual(0, result);
    }
  }
}