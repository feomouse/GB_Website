using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Threading.Tasks;

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
      var user = new AppUser("1074393541@qq.com");
      user.SetHashPassword("125256");

      IdentityResult result = config.UserRepository.CreateAsync(user).GetAwaiter().GetResult();

      Assert.AreEqual(true, result.Succeeded);
    }

    /// <summary>
    /// 添加用户到角色, 判断是否添加成功
    /// </summary>
    [TestMethod]
    public void TestAddUserToRoleAsyncAndIsInRoleAsync()
    {
      var user = new AppUser("1074393555@qq.com");
      user.SetHashPassword("125556");

      IdentityResult result = config.UserRepository.CreateAsync(user).GetAwaiter().GetResult();
      
      IdentityResult addResult = config.UserRepository.MyAddToRoleAsync(user, "customer").GetAwaiter().GetResult();
      bool testResult = config.UserRepository.IsInRoleAsync(user, "customer").GetAwaiter().GetResult();

      Assert.AreEqual(true, addResult.Succeeded);
      Assert.AreEqual(true, testResult);
    }

    /// <summary>
    /// 根据用户实体获取用户主键
    /// </summary>
    [TestMethod]
    public void TestGetUserIdAsync()
    {
      var user = new AppUser("1454393555@qq.com");
      user.SetHashPassword("1255546");

      IdentityResult result = config.UserRepository.CreateAsync(user).GetAwaiter().GetResult();

      var id = config.UserRepository.GetUserIdAsync(user);

      Assert.IsNotNull(id);
    }

    [TestMethod]
    public void TestPasswordSignInAsync()
    {
      var result = config.UserRepository.PasswordSignInAsync("111141221@qq.com", "123123123");
    
      var ress = result.GetAwaiter().GetResult();

      Assert.AreEqual(true, ress.Succeeded);
    }
  }
}