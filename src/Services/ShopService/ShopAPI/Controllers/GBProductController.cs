using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopAPI.ViewModels;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
  [Route("v1/api/shop/GBProduct")]
  public class GBProductController : ControllerBase
  {
    private IMediator _mediator;
    private IShopQuery _query;

    public GBProductController ( IMediator mediator, IShopQuery query)
    {
      _mediator = mediator;
      _query = query;
    }

/*     [HttpGet]
    public ActionResult<GBProduct> GetGBProductByName (string name)
    {
      GBProduct gbProduct = _query.getGBProductByName(name);

      return Ok(gbProduct);
    } */

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("add")]
    public ActionResult AddGBProduct ([FromBody]AddGBProductCommand gbProduct )
    {
      int num = _mediator.Send(gbProduct, default(CancellationToken)).GetAwaiter().GetResult();

      if (num == 0)
      {
        return BadRequest("Create error");
      }

      return Ok();
    } 

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("GBProducts")]
    public ActionResult GetGBProducts ([FromQuery] string shopName)
    {
      List<GBProduct> gbProducts = _query.getGBProductsByShopName(shopName);

      List<GBProductsVIewModel> gbProductsViews = new List<GBProductsVIewModel>();

      foreach(var p in gbProducts)
      {
        gbProductsViews.Add(new GBProductsVIewModel(p.PkId, p.ProductName, p.OrinPrice, p.Price, p.Quantity, p.VailSDate, p.VailEDate, p.VailTime
                                                  , p.Img, p.Remark, p.IsDisplay, p.PraiseNum, p.MSellNum, p.ProductTypeId));
      }

      return Ok(gbProductsViews);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("Update")]
    public ActionResult UpdateGBProduct ([FromBody] UpdateGBProductCommand command)
    {
      GBProduct gbProduct = _mediator.Send(command).GetAwaiter().GetResult();
 
      if(gbProduct == null)
      {
        return BadRequest("err");
      }
      return Ok(gbProduct);
    }
  }
}