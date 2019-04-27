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
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Route("add")]
    public ActionResult AddGBProduct ([FromBody]AddGBProductCommand gbProduct )
    {
      int num = _mediator.Send(gbProduct, default(CancellationToken)).GetAwaiter().GetResult();

      if (num == 0)
      {
        return BadRequest("Create error");
      }

      return StatusCode(201);
    } 

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("GBProducts")]
    public ActionResult GetGBProducts ([FromQuery] string shopName, string province, string city)
    {
      List<GBProduct> gbProducts = _query.getGBProductsByShopName(shopName, province, city);

      List<GBProductsVIewModel> gbProductsViews = new List<GBProductsVIewModel>();

      foreach(var p in gbProducts)
      {
        gbProductsViews.Add(new GBProductsVIewModel(p.PkId, p.ProductName, p.OrinPrice, p.Price, p.Quantity, p.VailSDate, p.VailEDate, p.VailTime
                                                  , p.Img, p.Remark, p.IsDisplay, p.PraiseNum, p.MSellNum, p.ProductTypeId));
      }

      return Ok(gbProductsViews);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("ProductType/GBProducts")]
    public ActionResult GetGBProductsByProductTypeId([FromHeader] string productTypeId)
    {
      List<GBProduct> gbProducts = _query.getGBProductByProductTypeId(productTypeId);

      List<GBProductsVIewModel> gbProductsViews = new List<GBProductsVIewModel>();

      foreach(var p in gbProducts)
      {
        gbProductsViews.Add(new GBProductsVIewModel(p.PkId, p.ProductName, p.OrinPrice, p.Price, p.Quantity, p.VailSDate, p.VailEDate, p.VailTime
                                                  , p.Img, p.Remark, p.IsDisplay, p.PraiseNum, p.MSellNum, p.ProductTypeId));
      }

      return Ok(gbProductsViews);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("GBProductKey")]
    public ActionResult GetGBProductKeyByName ([FromQuery] string productName)
    {
       string result = _query.getGBProductByName(productName);

       if(result == null) return BadRequest();

       return Ok(result);
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

    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [Route("Delete")]
    public ActionResult Delete ([FromQuery]string gbProduct)
    {
      int result = _mediator.Send(new DeleteGBProductCommand(gbProduct)).GetAwaiter().GetResult();

      if(result == 0)
      {
        return BadRequest("Delete err");
      }

      return StatusCode(204);
    }
  }
}