using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Application.Command;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
  [Route("v1/api/[controller]")]
    public class GBProductItemController : ControllerBase
    {
      private IMediator _mediator;
      private IQuery _query;

      public GBProductItemController ( IMediator mediator, IQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      public ActionResult<GBProductItem> GetGBProductItemByGbIdAndName (Guid gbid, string name)
      {
        GBProductItem gbProductItem = _query.getGBProductItemByGbIdAndName(gbid, name);

        return Ok(gbProductItem);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("add")]
      public async Task<ActionResult<GBProductItem>> AddGBProductItem ([FromBody] AddGBProductItemCommand gbProductItem )
      {
        int num = await _mediator.Send(gbProductItem);

        if ( num == 0)
        {
          return BadRequest();
        }

        return CreatedAtAction(nameof(GetGBProductItemByGbIdAndName), new { gbid = gbProductItem.GbProductId, name = gbProductItem.GbItemName}, gbProductItem);
      } 

    }
}