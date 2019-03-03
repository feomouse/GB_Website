using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB_Project.Services.IdentityService.IdentityAPI.Controllers;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using Moq;
using GB_Project.Services.IdentityService.IdentityAPI.ViewModels;
using GB_Project.Services.IdentityService.IdentityAPI.Query;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using GB_Project.EventBus.EventBusMQ;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using System;


namespace GB_Project.Services.IdentityService.UnitTests.IdentityAPIControllerUnitTests
{
    [TestClass]
    public class RegisterControllerUnitTest
    {
        [TestMethod]
        public void TestRegisterController1()
        {
          var userQuery = new Mock<IUserQuery>();
          userQuery.Setup(r => r.FindUserByEmail("")).
                    Returns(new AppUser("", ""));
          var eventBusPub = new Mock<IEventBusPublisher>();
          var mediator = new Mock<IMediator>();

          var controller = new RegisterController(userQuery.Object, eventBusPub.Object, mediator.Object);
          var model = new RegisterViewModel(){
              Email = "",
              Password = "",
              ConfirmedPassword = "",
              Role = ""
          };

          var result = controller.Register(model).GetAwaiter().GetResult();

          Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
          Assert.AreEqual("Already exist", result.Value);
        }

        [TestMethod]
        public void TestRegisterController2()
        {
            var userQuery = new Mock<IUserQuery>();
            userQuery.Setup(r => r.FindUserByEmail(""))
                     .Returns((AppUser)null);
            var eventBusPub = new Mock<IEventBusPublisher>();
            var mediator = new Mock<IMediator>();

            var RegisterController = new RegisterController(userQuery.Object, eventBusPub.Object, mediator.Object);
            
            var model = new RegisterViewModel(){
              Email = "",
              Password = "1",
              ConfirmedPassword = "2",
              Role = ""
            };
            var result = RegisterController.Register(model).GetAwaiter().GetResult();

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual("two different password", result.Value);
        }

        [TestMethod]
        public void TestRegisterController3()
        {
            var userQuery = new Mock<IUserQuery>();
            userQuery.Setup(r => r.FindUserByEmail(""))
                     .Returns((AppUser)null);
            var eventBusPub = new Mock<IEventBusPublisher>();
            var mediator = new Mock<IMediator>();
            mediator.Setup(r => r.Send(It.IsAny<RegistryCommand>(), default(CancellationToken))).
                     Returns(Task.FromResult<string>(""));

            var RegisterController = new RegisterController(userQuery.Object, eventBusPub.Object, mediator.Object);
            
            var model = new RegisterViewModel(){
              Email = "",
              Password = "1",
              ConfirmedPassword = "1",
              Role = ""
            };
            var result = RegisterController.Register(model).GetAwaiter().GetResult();

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual("Create Error", result.Value);
        }

        [TestMethod]
        public void TestRegisterController4()
        {
            var userQuery = new Mock<IUserQuery>();
            userQuery.Setup(r => r.FindUserByEmail(""))
                     .Returns((AppUser)null);
            var eventBusPub = new Mock<IEventBusPublisher>();
            var mediator = new Mock<IMediator>();
            mediator.Setup(r => r.Send(It.IsAny<RegistryCommand>(), default(CancellationToken))).
                     Returns(Task.FromResult<string>(Guid.NewGuid().ToString()));

            var RegisterController = new RegisterController(userQuery.Object, eventBusPub.Object, mediator.Object);
            
            var model = new RegisterViewModel(){
              Email = "",
              Password = "1",
              ConfirmedPassword = "1",
              Role = ""
            };
            var result = RegisterController.Register(model).GetAwaiter().GetResult();

            Assert.AreEqual("create successed", result.Value);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
