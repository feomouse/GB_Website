using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediatR;
using Moq;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Context;
using Microsoft.AspNetCore.Identity;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.IdentityService.IdentityAPI.Query;
using GB_Project.Services.IdentityService.IdentityAPI.ViewModels;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.IdentityService.IdentityAPI.Controllers;
using System.Collections.Generic;

namespace GB_Project.Services.IdentityService.UnitTests.IdentityAPIControllerUnitTests
{
  [TestClass]
  public class SignInControllerUnitTests
  {
    [TestMethod]
    public void TestSignInControllerNoUser()
    {
      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<SignInCommand>(), default(CancellationToken)))
              .Returns(Task.FromResult(true));

      var query = new Mock<IUserQuery>();
      query.Setup(q => q.FindUserByEmail("")).
            Returns((AppUser)null);

      var model = new SignInViewModel("", "");

      var controller = new SignInController(mediator.Object, query.Object);

      var result = (StatusCodeResult)controller.SignIn(model).GetAwaiter().GetResult();

      Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
      Assert.AreEqual(401, result.StatusCode);
    }

    [TestMethod]
    public void TestSignInControllerInvalidPassword()
    {
      var user = new AppUser("", ""); 

      var mediator = new Mock<IMediator>();
      mediator.Setup(s => s.Send(It.IsAny<SignInCommand>(), default(CancellationToken)))
              .Returns(Task.FromResult(false));

      var query = new Mock<IUserQuery>();
      query.Setup(q => q.FindUserByEmail("")).
            Returns(new AppUser("", ""));

      var model = new SignInViewModel("", "");

      var controller = new SignInController(mediator.Object, query.Object);

      var result = (StatusCodeResult)controller.SignIn(model).GetAwaiter().GetResult();

      Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
      Assert.AreEqual(403, result.StatusCode);
    }

    [TestMethod]
    public void TestSignInControllerOK()
    {
        var user = new AppUser("", ""); 

        var mediator = new Mock<IMediator>();
        mediator.Setup(s => s.Send(It.IsAny<SignInCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(true));

        var query = new Mock<IUserQuery>();
        query.Setup(q => q.FindUserByEmail("")).
              Returns(new AppUser("", ""));
        query.Setup(q => q.GetRolesAsync(It.IsAny<AppUser>())).
              Returns(new List<string>());

        var model = new SignInViewModel("", "");

        var controller = new SignInController(mediator.Object, query.Object);

        var result = (ObjectResult)controller.SignIn(model).GetAwaiter().GetResult();

        Assert.AreEqual(200, result.StatusCode);
    }
  }
}