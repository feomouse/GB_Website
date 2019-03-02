using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Application.Command;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    public class ShopController : ControllerBase
    {
      private IMediator _mediator;
      private IQuery _query;

      public ShopController ( IMediator mediator, IQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public ActionResult<Shop> GetShopByName ([FromQuery] string name)
      {
        Shop shop = _query.getShopByName(name);

        return Ok(shop);
      }

      [HttpPost]
      [Route("create")]
      [ProducesResponseType(201)]
      //[ProducesResponseType(201)]
      [ProducesResponseType(400)]
      public async Task<ActionResult<Shop>> CreateShop ([FromBody]CreateShopCommand shop)
      {
        int num = await _mediator.Send(shop);

        if (num == 0)
        {
          return BadRequest();
        }

        return CreatedAtAction(nameof(GetShopByName), new { name = shop.Name}, shop);
      }
    }
}