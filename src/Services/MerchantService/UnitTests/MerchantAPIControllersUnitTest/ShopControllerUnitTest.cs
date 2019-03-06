using Moq;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Controllers;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace GB_Project.Services.MerchantService.UnitTests.MerchantAPIControllersUnitTest
{
  [TestClass]
  public class ShopControllerUnitTest
  {
    [TestMethod]
    public void TestAddShopIdControllerNoMerchant()
    {
      var query = new Mock<IMerchantQuery>();
      query.Setup(s => s.GetMerchantBasicByMerchantId(Guid.NewGuid().ToString())).
            Returns((MerchantBasic)null);

      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<AddShopCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(1));

      var controller =new ShopController(query.Object, mediator.Object);

      var model = new ShopViewModel("", "");
      var result = controller.AttachShopToMerchant(model).GetAwaiter().GetResult();  

      Assert.AreEqual(401, result.StatusCode);
    }

    [TestMethod]
    public void TestAddShopIdControllerAddError()
    {
      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<AddShopCommand>(), default(CancellationToken))).
               Returns(Task.FromResult(0));

      var id = Guid.NewGuid().ToString();
      var query = new Mock<IMerchantQuery>();
      query.Setup(s => s.GetMerchantBasicByMerchantId(id)).
            Returns(It.IsNotNull<MerchantBasic>()); 

      query.Verify(s => s.GetMerchantBasicByMerchantId(id));

      var controller =new ShopController(query.Object, mediator.Object);

      var model = new ShopViewModel(id, "");
      var result = controller.AttachShopToMerchant(model).GetAwaiter().GetResult();  

      Assert.AreEqual(400, result.StatusCode);
    }
  }
}