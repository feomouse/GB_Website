using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using GB_Project.Services.MerchantService.MerchantAPI.Controller;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using MediatR;
using System;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System.Threading.Tasks;

namespace GB_Project.Services.MerchantService.UnitTests.MerchantAPIControllersUnitTest
{
    [TestClass]
    public class IdentityControllerUnitTest
    {
        [TestMethod]
        public void TestMerchantControllerAddIdentity()
        {
            var query = new Mock<MerchantQuery>();
            query.Setup(s => s.GetMerchantBasicByMerchantId(Guid.NewGuid())).
                  Returns((MerchantBasic)null);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s => s.Send(It.IsAny<AddIdentityCommand>())).
                     Returns(Task.FromResult(1));

            var controller = new MerchantController(query.Object, mediator.Object);

            AptitudeViewModel model = new AptitudeViewModel("", "", "", "", "", "", "", "", "", DateTime.Now, DateTime.Now, "");
            var result = (StatusCodeResult)controller.AddAptitude(model);

            Assert.AreEqual(401, result.StatusCode);
        }
    }
}
