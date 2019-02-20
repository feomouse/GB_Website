using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_project.Services.ShopService.ShopAPI.Application.Command;
using GB_project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Controllers
{
  [Route("v1/api/[controller]")]
    public class GBProductController : ControllerBase
    {
      private IMediator _mediator;
      private IQuery _query;

      public GBProductController ( IMediator mediator, IQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      public ActionResult<GBProduct> GetGBProductByName (string name)
      {
        GBProduct gbProduct = _query.getGBProductByName(name);

        return Ok(gbProduct);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("add")]
      public async Task<ActionResult<GBProduct>> AddGBProductItem ([FromBody] AddGBProductCommand gbProduct )
      {
        int num = await _mediator.Send(gbProduct);

        if ( num == 0)
        {
          return BadRequest();
        }

        return CreatedAtAction(nameof(GetGBProductByName), new { name = gbProduct.ProductName}, gbProduct);
      } 

    }
}