using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using System.Threading.Tasks;
using GB_Project.Services.IdentityService.IdentityAPI.ViewModels;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Threading;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using System;
using GB_Project.Services.IdentityService.IdentityAPI.IntergrationEvents.Events;
using MediatR;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using GB_Project.Services.IdentityService.IdentityAPI.Query;

namespace GB_Project.Services.IdentityService.IdentityAPI.Controllers
{
  [Route("v1/api/[controller]")]
  public class RegisterController : ControllerBase
  {
    private IUserQuery _userQuery;
    
    private IEventBusPublisher _eventBusPublisher;

    private IMediator _mediator;

    public RegisterController(IUserQuery userQuery, IEventBusPublisher eventBusPublisher, IMediator mediator)
    {
      _userQuery = userQuery;

      _eventBusPublisher = eventBusPublisher;

      _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ObjectResult> Register([FromBody]RegisterViewModel model)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest("Invail state");
      }

      // 1.检查用户是否存在
      if(_userQuery.FindUserByEmail(model.Email) != null)
      {
        return BadRequest("Already exist");
      }
 
      // 2.检查两侧输入密码是否相同
      if(model.Password != model.ConfirmedPassword)
      {
        return BadRequest("two different password");
      }

      var id = _mediator.Send(new RegistryCommand(model.Email, model.Password, model.Role)).Result;

      // 3.检查注册用户是否成功
      if(id == "")
      {
        return BadRequest("Create Error");
      }

      Guid gid = Guid.Parse(id);
      var @event = new MerchantRegisteredIntergrationEvent(gid);

      _eventBusPublisher.Publish(@event);

      return Ok("create successed");
    }
  }    
}