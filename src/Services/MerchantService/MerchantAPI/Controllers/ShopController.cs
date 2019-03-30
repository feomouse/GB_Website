using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using System.Threading;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;

namespace GB_Project.Services.MerchantService.MerchantAPI.Controllers
{
  [Route("v1/api/merchant")]
  [ApiController]
  public class ShopController : ControllerBase
  {
     private IMerchantQuery _query;

     private IMediator _mediator;
     public ShopController(IMerchantQuery query, IMediator mediator)
     {
       _query = query;
       _mediator = mediator;
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
  }
}