using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using System.Threading;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System.Collections.Generic;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.Events;

namespace GB_Project.Services.MerchantService.MerchantAPI.Controllers
{
  [Route("v1/api/merchant")]
  [ApiController]
  public class ShopController : ControllerBase
  {
     private IMerchantQuery _query;

     private IMediator _mediator;

     private IEventBusPublisher _publisher;

     public ShopController(IMerchantQuery query, IMediator mediator, IEventBusPublisher publisher)
     {
       _query = query;
       _mediator = mediator;
       _publisher = publisher;
     }

     [HttpPost]
     [Route("AttachShop")]
     [ProducesResponseType(400)]
     [ProducesResponseType(200)]
     public async Task<StatusCodeResult> AttachShopToMerchant([FromBody] AddShopCommand model)
     {
       if(!ModelState.IsValid)
       {
         return new StatusCodeResult(400);
       }

       var result = await _mediator.Send(model, default(CancellationToken));
     
       if(result == 0)
       {
         return new StatusCodeResult(400);
       }  

       return new StatusCodeResult(200);
     }

     [HttpPost]
     [Route("BindShop")]
     public async Task<StatusCodeResult> BindShopToMerchant([FromBody] BindShopCommand model)
     {
       if(!ModelState.IsValid)
       {
         return new StatusCodeResult(400);
       }

       var result = await _mediator.Send(model, default(CancellationToken));
     
       if(result == 0)
       {
         return new StatusCodeResult(400);
       }  

        var @event = new BindShopIntergrationEvent(new Guid(model.MerchantId), new Guid(model.ShopId));

        _publisher.Publish(@event);

       return new StatusCodeResult(200);
     }

     [HttpGet]
     [Route("GetShops")]
     public ActionResult<IList<MerchantShop>> GetMerchantShops([FromHeader] string merchantId)
     {
        return Ok(_query.GetMerchantShops(merchantId));
     }
  }
}