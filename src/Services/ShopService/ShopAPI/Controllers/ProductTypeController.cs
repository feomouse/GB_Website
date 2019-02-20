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
    public class ProductTypeController : ControllerBase
    {
      private IMediator _mediator;
      private IQuery _query;

      public ProductTypeController ( IMediator mediator, IQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      public ActionResult<ProductType> GetProductTypeByNameAndShopId (string name, Guid shopId)
      {
        ProductType productType = _query.getProductTypeByNameAndShopId(name, shopId);

        return Ok(productType);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("add")]
      public async Task<ActionResult<ProductType>> AddProductType ([FromBody]AddProductTypeCommand productType )
      {
        int num = await _mediator.Send(productType);

        if ( num == 0)
        {
          return BadRequest();
        }

        return CreatedAtAction(nameof(GetProductTypeByNameAndShopId), new { name = productType.TypeName, shopId = productType.ShopId}, productType);
      } 

    }
}