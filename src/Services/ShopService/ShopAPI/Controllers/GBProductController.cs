using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopAPI.ViewModels;
using System.Linq;

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
    public ActionResult GetGBProducts ([FromQuery] string shopName, [FromQuery]string province, [FromQuery]string city, [FromQuery]string district)
    {
      List<GBProduct> gbProducts = _query.getGBProductsByShopName(shopName, province, city, district);
 
      if(gbProducts == null) return BadRequest();

      List<GBProductsVIewModel> gbProductsViews = new List<GBProductsVIewModel>();

      foreach(var p in gbProducts)
      { 
        var img = "";
        var imgs = _query.getGBProductImgs(p.PkId.ToString());
        if(imgs.Count() != 0) {
          img = imgs[0].Img; 
        }
 
        gbProductsViews.Add(new GBProductsVIewModel(p.PkId, p.ProductName, p.OrinPrice, p.Price, p.Quantity, p.VailSDate, p.VailEDate, p.VailTime
                                                  , p.Remark, p.Detail, p.IsDisplay, p.PraiseNum, p.MSellNum, p.ProductTypeId, img));
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

      if(gbProducts == null) return BadRequest();
      
      List<GBProductsVIewModel> gbProductsViews = new List<GBProductsVIewModel>();

      foreach(var p in gbProducts)
      {
        var img = "";
        var imgs = _query.getGBProductImgs(p.PkId.ToString());
        if(imgs.Count() != 0) {
          img = imgs[0].Img; 
        }

        gbProductsViews.Add(new GBProductsVIewModel(p.PkId, p.ProductName, p.OrinPrice, p.Price, p.Quantity, p.VailSDate, p.VailEDate, p.VailTime
                                                  , p.Remark, p.Detail, p.IsDisplay, p.PraiseNum, p.MSellNum, p.ProductTypeId, img));
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
      return Ok(new {pkId= gbProduct.PkId, productName= gbProduct.ProductName, orinPrice= gbProduct.OrinPrice, price= gbProduct.Price,
                     quantity= gbProduct.Quantity, vailSDate= gbProduct.VailSDate, vailEDate= gbProduct.VailEDate, vailTime= gbProduct.VailTime,
                    remark= gbProduct.Remark, isDisplay= gbProduct.IsDisplay, praiseNum= gbProduct.PraiseNum, mSellNum= gbProduct.MSellNum,
                    productTypeId= gbProduct.ProductTypeId});
    }
    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [Route("Delete")]
    public ActionResult Delete ([FromHeader]string gbProductId)
    {
      int result = _mediator.Send(new DeleteGBProductCommand(gbProductId)).GetAwaiter().GetResult();

      if(result == 0)
      {
        return BadRequest("Delete err");
      }

      return StatusCode(204);
    }

    [HttpGet]
    [Route("GetGBProductImgs")]
    public ActionResult GetGBProductImgs([FromHeader]string gbProductId)
    {
      return Ok(_query.getGBProductImgs(gbProductId).Select(gm => new {pkId = gm.MGBProductId, img = gm.Img}));
    }

    [HttpPost]
    [Route("SetGBProductImg")]
    public ActionResult SetGBProductImg([FromBody] AddGBProductImgCommand command)
    {
       var result = _mediator.Send(command).GetAwaiter().GetResult();

        if(result == 0) return BadRequest();

        return Ok();
    }

    [HttpPost]
    [Route("GetGBProductsFirstImg")]
    public ActionResult GetGBProductsFirstImg([FromBody] List<string> gbProductIds)
    {
      IList<GBProductImg> imgs = new List<GBProductImg>();

      foreach(var i in gbProductIds)
      {
        imgs.Add( _query.getGBProductImgs(i)[0]);
      }

      return Ok(imgs.Select(img => new {pkId = img.MGBProductId, img = img.Img}));
    }
  }
}