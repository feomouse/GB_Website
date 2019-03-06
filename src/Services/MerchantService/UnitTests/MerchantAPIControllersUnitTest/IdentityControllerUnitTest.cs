using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using GB_Project.Services.MerchantService.MerchantAPI.Controllers;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using MediatR;
using System;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace GB_Project.Services.MerchantService.UnitTests.MerchantAPIControllersUnitTest
{
    [TestClass]
    public class IdentityControllerUnitTest
    {
        [TestMethod]
        public void TestMerchantControllerAddIdentity()
        {
            var query = new Mock<IMerchantQuery>();
            query.Setup(s => s.GetMerchantBasicByMerchantId(Guid.NewGuid().ToString())).
                  Returns((MerchantBasic)null);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s => s.Send(It.IsAny<AddIdentityCommand>(), default(CancellationToken))).
                     Returns(Task.FromResult(It.IsNotNull<MerchantBasic>()));

            mediator.Setup(s => s.Send(It.IsAny<AttachIdentityIdToMerchantCommand>(), default(CancellationToken))).
                     Returns(Task.FromResult(1));

            var controller = new IdentityController(query.Object, mediator.Object);

            AptitudeViewModel model = new AptitudeViewModel("", "", "", "", "", "", "", "", "", DateTime.Now, DateTime.Now, "");
            var result = controller.AddAptitude(model);

            Assert.AreEqual(401, result.StatusCode);
        }

        [TestMethod]
        public void TestMerchantControllerAddIdentityAttachFail()
        {
            var mid = Guid.NewGuid().ToString();
            var query = new Mock<IMerchantQuery>();
            query.Setup(s => s.GetMerchantBasicByMerchantId(mid)).
                  Returns(It.IsNotNull<MerchantBasic>());
            
            query.Verify(s => s.GetMerchantBasicByMerchantId(mid));
                  
            var mediator = new Mock<IMediator>();
            mediator.Setup(s => s.Send(It.IsAny<AddIdentityCommand>(), default(CancellationToken))).
                     Returns(Task.FromResult(It.IsNotNull<MerchantBasic>()));

            mediator.Setup(s => s.Send(It.IsAny<AttachIdentityIdToMerchantCommand>(), default(CancellationToken))).
                     Returns(Task.FromResult(0));
          
            var controller = new IdentityController(query.Object, mediator.Object);

            AptitudeViewModel model = new AptitudeViewModel(mid, "", "", "", "", "", "", "", "", DateTime.Now, DateTime.Now, "");
            var result = controller.AddAptitude(model);

            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
