using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediatR;
using Moq;
using System;
using GB_Project.Services.UserService.UserAPI.Application.Commands;
using GB_Project.Services.UserService.UserAPI.ViewModels;
using GB_Project.Services.UserService.UserAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.UserService.UserAPI.Query;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using System.Threading.Tasks;
using System.Threading;

namespace GB_Project.Services.UserService.UnitTests.UserAPIControllerUnitTest
{
  [TestClass]
  public class UserOpControllerUnitTest
  {
    [TestMethod]
    public void TestSetImgNoUser()
    {
      var query = new Mock<IUserQuery>();
      query.Setup(s => s.GetUserByUserId(Guid.NewGuid().ToString())).
            Returns((User)null);
      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<SetImgCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(1));

      var controller = new UserOperateController(query.Object, mediator.Object);

      var model = new SetImgViewModel(Guid.NewGuid().ToString(), "");
      var result = controller.SetImg(model).GetAwaiter().GetResult();

      Assert.AreEqual(401, result.StatusCode);
    }

    [TestMethod]
    public void TestSetImgSetError()
    {
      var query = new Mock<IUserQuery>();
      query.Setup(s => s.GetUserByUserId(Guid.NewGuid().ToString())).
            Returns(new User("", ""));
      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<SetImgCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(0));

      var controller = new UserOperateController(query.Object, mediator.Object);

      var model = new SetImgViewModel(Guid.NewGuid().ToString(), "");
      var result = controller.SetImg(model).GetAwaiter().GetResult();

      Assert.AreEqual(400, result.StatusCode);
    }

    [TestMethod]
    public void TestSetImgOK()
    {
      var query = new Mock<IUserQuery>();
      query.Setup(s => s.GetUserByUserId(Guid.NewGuid().ToString())).
            Returns(new User("", ""));
      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<SetImgCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(1));

      var controller = new UserOperateController(query.Object, mediator.Object);

      var model = new SetImgViewModel(Guid.NewGuid().ToString(), "");
      var result = controller.SetImg(model).GetAwaiter().GetResult();

      Assert.AreEqual(200, result.StatusCode);
    }

    [TestMethod]
    public void TestSetAddressOK()
    {
      string id = Guid.NewGuid().ToString();
      var query = new Mock<IUserQuery>();
      query.Setup(q => q.GetUserByUserId(id)).
            Returns(It.IsNotNull<User>());

      query.Verify(q => q.GetUserByUserId(id));

      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<SetAddressCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(1));

      var controller = new UserOperateController(query.Object, mediator.Object);

      var model = new SetAddressViewModel(Guid.NewGuid().ToString(), "");
      var result = controller.SetUserLocation(model).GetAwaiter().GetResult();

      Assert.AreEqual(200, result.StatusCode);
    }
  }
}