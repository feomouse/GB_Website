using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System.Threading;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.Events;

namespace GB_Project.Services.MerchantService.MerchantAPI.Controllers
{
  [Route("v1/api/merchant")]
  [ApiController]
  public class IdentityController : ControllerBase
  {
    private IMerchantQuery _query;

    private IMediator _mediator;

    private IEventBusPublisher _publisher;

    public IdentityController(IMerchantQuery query, IMediator mediator, IEventBusPublisher publisher)
    {
      _query = query;
      _mediator = mediator;
      _publisher = publisher;
    }

    [HttpPost]
    [Route("AddIdentity")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult AddAptitude([FromBody] AddIdentityCommand command)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      var resultCreate = _mediator.Send(command, default(CancellationToken)).GetAwaiter().GetResult();

      if(resultCreate != null)
      {
        return Ok(resultCreate);
      } 

      return BadRequest("create error");
    }

    [HttpPost]
    [Route("CheckIdentity")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult CheckIdentity([FromBody] CheckIdentityCommand command)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      var result = _mediator.Send(command, default(CancellationToken)).GetAwaiter().GetResult();

      if(result != 0)
      {
        var @event = new MerchantIsIdentitiedIntergrationEvent(new Guid(command.MerchantId), command.CheckResult);
        _publisher.Publish(@event);

        return new StatusCodeResult(200);
      }

      else return new BadRequestObjectResult("check fail");
    }
  }
}