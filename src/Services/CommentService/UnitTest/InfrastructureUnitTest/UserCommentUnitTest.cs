using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using System;

namespace GB_Project.Services.CommentService.UnitTest.InfrastructureUnitTest
{
  [TestClass]
  public class UserCommentUnitTest
  {
    private BasicConfig _config;
    public UserCommentUnitTest()
    {
      _config = new BasicConfig();
    }

    [TestMethod]
    public void TestAddUserComment()
    {
      var comment = new UserComment("我是注释", DateTime.Now, 3, "d", Guid.NewGuid(), Guid.NewGuid(), 
                                    Guid.NewGuid(), "user");
      int result = _config.repository.AddUserComment(comment);

      Assert.AreNotEqual(0, result);
    }

    [TestMethod]
    public void TestGetUserCommentByOrderId()
    {
      var result = _config.repository.GetUserCommentByOrderId("6DD40D8E-8E3B-4535-B0A0-867BAF082D23");

      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void TestGetUserCommentsByProductId()
    {
      var result = _config.repository.GetUserCommentsByProductId("826D2F8F-5770-4AC2-917B-76B4C77ED374");

      Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void TestGetUserCommentsByShopId()
    {
      var res = _config.repository.GetUserCommentsByShopId("826D2F8F-5770-4A2C-917B-76B4C77ED374");

      Assert.AreEqual(2, res.Count);
    }

    [TestMethod]
    public void TestGetUserCommentByCommentId()
    {
      var result = _config.repository.GetUserCommentByCommentId("E02D4D40-EAE0-46FD-80FB-3985A133EDFF");

      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void TestAddReplyComment()
    {
      var rcom = new ReplyComment("i am reply", DateTime.Now);
      rcom.SetUserComment(_config.repository.GetUserCommentByOrderId("6DD40D8E-8E3B-4535-B0A0-867BAF082D23"));
      var result = _config.repository.AddReplyComment(rcom);

      Assert.AreNotEqual(0, result);
    }
  } 
}