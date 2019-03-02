using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Application.Command;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    public class ProductController : ControllerBase
    {
      private IMediator _mediator;
      private IQuery _query;

      public ProductController ( IMediator mediator, IQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      public ActionResult<Product> GetProductByName (string name)
      {
        Product product = _query.getProductByName(name);

        return Ok(product);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("menu/add")]
      public async Task<ActionResult<Product>> AddProduct ([FromBody]AddProductCommand product )
      {
        int num = await _mediator.Send(product);

        if ( num == 0)
        {
          return BadRequest();
        }

        return CreatedAtAction(nameof(GetProductByName), new { name = product.ProductName}, product);
      } 

    }
}