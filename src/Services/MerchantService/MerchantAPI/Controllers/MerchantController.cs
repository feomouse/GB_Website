using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using System.Threading;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System.Linq;

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

     [HttpGet]
     [Route("GetMerchantShopListIsNotChecked")]
     public ActionResult GetMerchantShopListIsNotChecked([FromQuery] int page)
     {
       var merchantShops = _query.GetMerchantShopListNotChecked(page);

       if(merchantShops == null) return BadRequest();

       else return Ok(merchantShops.Select(ms => new {mBasicId = ms.MBasicId, shopId = ms.ShopId, mIdentityId = ms.MIdentityId, isChecked = ms.IsChecked}));
     }

     [HttpGet]
     [Route("GetMerchantList")]
     public ActionResult GetMerchantList([FromQuery] int page)
     {
        var merchants = _query.GetMerchantBasics(page);

        if(merchants == null) return BadRequest();

        else return Ok(merchants.Select(m => new {authPkId = m.AuthPkId}));
     }
  }
}