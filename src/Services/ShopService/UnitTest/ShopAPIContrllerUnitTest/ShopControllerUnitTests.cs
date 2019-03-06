using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Controllers;
using Moq;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GB_Project.Services.ShopService.UnitTest.ShopAPIControllerUnitTest
{
  [TestClass]
  public class ShopControllerUnitTests
  {
    [TestMethod]
    public void TestGetShopByNameOk()
    {
      var mediator = new Mock<IMediator>();
      var query = new Mock<IShopQuery>();
      query.Setup(s => s.getShopByName(""))
           .Returns(new Shop());

      var controller = new ShopController(mediator.Object, query.Object);

      var result = (OkObjectResult)controller.GetShopByName(It.IsNotNull<string>());

      Assert.IsNotNull(result.Value);
      Assert.AreNotEqual("", result.Value);
    }

    [TestMethod]
    public void TestGetShopByNameNoShop()
    {
      var mediator = new Mock<IMediator>();
      var query = new Mock<IShopQuery>();
      query.Setup(s => s.getShopByName(It.IsAny<string>())).
            Returns((Shop)null);

      var controller = new ShopController(mediator.Object, query.Object);

      var result = (OkObjectResult)controller.GetShopByName(It.IsNotNull<string>());

      Assert.AreEqual("", result.Value);
    }

    [TestMethod]
    public void TestCreateShopError()
    {
      var mediator = new Mock<IMediator>();
      var query = new Mock<IShopQuery>();

      mediator.Setup(s => s.Send(It.IsAny<CreateShopCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(0));

      var controller = new ShopController(mediator.Object, query.Object);

      var result = (StatusCodeResult)controller.CreateShop(It.IsNotNull<CreateShopCommand>());

      Assert.IsNotNull(result);
      Assert.AreEqual(400, result.StatusCode);
    }

    [TestMethod]
    public void TestCreateShopOk()
    {
      var mediator = new Mock<IMediator>();
      var query = new Mock<IShopQuery>();

      mediator.Setup(s => s.Send(It.IsAny<CreateShopCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(1));

      var controller = new ShopController(mediator.Object, query.Object);

      var result = (StatusCodeResult)controller.CreateShop(It.IsNotNull<CreateShopCommand>());

      Assert.IsNotNull(result);
      Assert.AreEqual(201, result.StatusCode);
    }
  }
}