using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;

namespace GB_Project.Services.IdentityService.UnitTests.IdentityInfrastructureUnitTests
{ 
  [TestClass]
  public class UserUnitTest{
    private BasicConfig config;

    public UserUnitTest()
    {
      config = new BasicConfig();
    }

    [TestMethod]
    /// <summary>
    /// 创建角色
    /// </summary>
    public void TestCreateRoleAsync()
    {
      var role = new AppRole("customer");
      IdentityResult result = config.RoleRepository.CreateAsync(role).GetAwaiter().GetResult();

      Assert.AreEqual(true, result.Succeeded);
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    [TestMethod]
    public void TestCreateUserAsync()
    {
      var user = new AppUser("1074393541@qq.com", "125256");
      IdentityResult result = config.UserRepository.CreateAsync(user).GetAwaiter().GetResult();

      Assert.AreEqual(true, result.Succeeded);
    }

    /// <summary>
    /// 添加用户到角色
    /// </summary>
    [TestMethod]
    public void TestAddUserToRoleAsync()
    {
      var user = new AppUser("1074393555@qq.com", "125556");
      IdentityResult result = config.UserRepository.CreateAsync(user).GetAwaiter().GetResult();
      
      IdentityResult addResult = config.UserRepository.MyAddToRoleAsync(user, "customer").GetAwaiter().GetResult();
      bool testResult = config.UserRepository.IsInRoleAsync(user, "customer").GetAwaiter().GetResult();

      Assert.AreEqual(true, addResult.Succeeded);
      Assert.AreEqual(true, testResult);
    }
  }
}