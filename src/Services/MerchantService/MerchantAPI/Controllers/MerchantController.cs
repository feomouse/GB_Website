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
  public class MerchantController : ControllerBase
  {
     private IMerchantQuery _query;

     private IMediator _mediator;
     public MerchantController(IMerchantQuery query, IMediator mediator)
     {
       _query = query;
       _mediator = mediator;
     }

     [HttpGet]
     [Route("GetMerchantBasic")]
     [ProducesResponseType(400)]
     [ProducesResponseType(200)]
     public ActionResult GetMerchantBasicInfo([FromHeader] string merchantId)
     {
       if(!ModelState.IsValid)
       {
         return new StatusCodeResult(400);
       }

       var merchantBasic = _query.GetMerchantBasicByMerchantId(merchantId);
     
       if(merchantBasic == null)
       {
         return new StatusCodeResult(400);
       }  

       return Ok(merchantBasic);
     }
  }
}