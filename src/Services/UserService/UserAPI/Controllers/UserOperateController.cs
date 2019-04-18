using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using MediatR;
using System;
using System.Threading.Tasks;
using GB_Project.Services.UserService.UserAPI.ViewModels;
using GB_Project.Services.UserService.UserAPI.Query;
using GB_Project.Services.UserService.UserAPI.Application.Commands;
using System.Collections.Generic;
using System.IO;
using GB_Project.Services.UserService.UserAPI.GetCommands;

namespace GB_Project.Services.UserService.UserAPI.Controllers
{
  [ApiController]
  [Route("v1/api/user")]
  public class UserOperateController : ControllerBase
  {
    private IUserQuery _query;

    private IMediator _mediator;

    public UserOperateController(IUserQuery query, IMediator mediator)
    {
      _query = query;

      _mediator = mediator;
    }

    [HttpGet()]
    [Route("userMessage")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult GetUserBasicMessage([FromHeader]string UserId )
    {
      var user = _query.GetUserByUserId(UserId);

      if (user == null)
      {
        return BadRequest("NO USER");
      }
      
      return Ok(user);
    }

    [HttpPost]
    [Route("SetUserName")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public StatusCodeResult SetUserName([FromBody]SetUserNameCommand command)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      var result = _mediator.Send(command).GetAwaiter().GetResult();

      if (result == 0)
      {
        return new StatusCodeResult(400);
      }

      return new StatusCodeResult(200);
    }

    [HttpPost]
    [Route("SetAddress")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public StatusCodeResult SetUserLocation([FromBody] SetAddressCommand command)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      var result = _mediator.Send(command).GetAwaiter().GetResult();

      if (result == 0)
      {
        return new StatusCodeResult(400);
      }

      return new StatusCodeResult(200);
    }

    [HttpPost]
    [Route("SetImg")]
    public async Task<ActionResult> UpLoadImg([FromBody]SetImgCommand command)
    {
      var user = _query.GetUserByUserId(command.UserId);

      if(user == null)
      {
        return new StatusCodeResult(401);
      }
    
      var result = await _mediator.Send(new SetImgCommand(command.UserId,command.FileName));

      if(result == "")
      {
        return new StatusCodeResult(400);
      }
      
      return Ok(result);
    }
  }
}