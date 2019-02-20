using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_project.Services.ShopService.ShopAPI.Application.Command;
using GB_project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    public class ShopMerchantController : ControllerBase
    {
       private IMediator _mediator;
       private IQuery _query;

       public ShopMerchantController ( IMediator mediator, IQuery query)
       {
         _mediator = mediator;
         _query = query;
       }

       [HttpGet]
       public ActionResult<ShopMerchant> GetShopMerchantByKey ( Guid merchantId, Guid shopId )
       {
          ShopMerchant merchant = _query.getShopMerchantByKey(merchantId, shopId);

          return Ok(merchant);
       }

       [HttpPost]
       [Route("setinfo/merchant")]
       [ProducesResponseType(201)]
       [ProducesResponseType(400)]
       public async Task<ActionResult<ShopMerchant>> AddShopMerchant ([FromBody]AddMerchantCommand shopMerchant )
       {
          int num = await _mediator.Send(shopMerchant);

          if ( num == 0)
          {
            return BadRequest();
          }

          return CreatedAtAction(nameof(GetShopMerchantByKey), new { merchantId = shopMerchant.MerchantId, shopId = shopMerchant.ShopId}, shopMerchant);
       }
    }
    
}