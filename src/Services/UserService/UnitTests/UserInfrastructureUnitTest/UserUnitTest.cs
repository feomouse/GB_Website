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
      User user = new User(new Guid("EE95ED97-571B-4664-AC6F-08D6A46D4941"), "1074093560@qq.com");
      int result = config.Repository.CreateUser(user);

      Assert.AreNotEqual(0, result);
    }

    [TestMethod]
    public void TestGetUserByUserId()
    {
      var user = config.Repository.GetUserByUserId("3DC6B686-4707-4602-9EA8-F92AD5BE491E");

      Assert.IsNotNull(user);
    }

    [TestMethod]
    public void TestSetUserLocation()
    {
      var user = config.Repository.GetUserByUserId("3DC6B686-4707-4602-9EA8-F92AD5BE491E");
      var result = config.Repository.SetUserLocation(user, "北京朝阳区人民广场");
    
      Assert.AreNotEqual(0, result);
    }

    [TestMethod]
    public void TestSetUserImg()
    {
      var user = config.Repository.GetUserByUserId("3DC6B686-4707-4602-9EA8-F92AD5BE491E");
      var result = config.Repository.SetUserImg(user, "/d/aa/xxxx.jpg");

      Assert.AreNotEqual(0, result);
    }
  }
}