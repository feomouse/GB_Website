using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopAPI.ViewModels;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events;
using System.Threading;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/shop")]
    public class ShopController : ControllerBase
    {
      private IMediator _mediator;
      private IShopQuery _query;

      private IEventBusPublisher _publisher;

      public ShopController ( IMediator mediator, IShopQuery query, IEventBusPublisher publisher)
      {
        _mediator = mediator;
        _query = query;
        _publisher = publisher;
      }

      [HttpGet]
      [Route("ShopTypies")]
      public ActionResult<List<ShopTypesViewModel>> GetShopTypies ()
      {
        var shopTypes = new List<ShopTypesViewModel>();
        shopTypes.Add(new ShopTypesViewModel(ShopType.beauty.Id, ShopType.beauty.Name, ShopType.beauty.Img));
        shopTypes.Add(new ShopTypesViewModel(ShopType.entertain.Id, ShopType.entertain.Name, ShopType.entertain.Img));
        shopTypes.Add(new ShopTypesViewModel(ShopType.food.Id, ShopType.food.Name, ShopType.food.Img));
        shopTypes.Add(new ShopTypesViewModel(ShopType.livingPlace.Id, ShopType.livingPlace.Name, ShopType.livingPlace.Img));
        shopTypes.Add(new ShopTypesViewModel(ShopType.learning.Id, ShopType.learning.Name, ShopType.learning.Img));
        
        return shopTypes;
      }  
      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("Create")]
      public ActionResult CreateShop ([FromBody]CreateShopCommand shop)
      {
        if (!ModelState.IsValid)
        {
          return new StatusCodeResult(400);
        }

         Shop createdShop = _mediator.Send(shop).GetAwaiter().GetResult();

        if (createdShop == null)
        {
          return new StatusCodeResult(400);
        }

        _publisher.Publish(new ShopIsCreatedIntergrationEvent(createdShop.PkId, new Guid(shop.Manager)));

        return new CreatedResult("", new CreatedShopViewModel(createdShop.PkId.ToString(), createdShop.RegisterId.ToString()));
      }

      [HttpGet]
      [Route("SearchShop")]
      public ObjectResult GetShopByName ([FromQuery] string name)
      {
        Shop shop = _query.getShopByName(name);

        if(shop == null)
        {
          return new BadRequestObjectResult("no shop");
        }

        var result = new SearchShopViewModel(shop.PkId.ToString(), shop.Name, shop.Province, shop.City, shop.District, shop.Location, shop.Pic, shop.Tel , shop.Type, shop.RegisterId.ToString());
        return new OkObjectResult(result);
      }

      [HttpGet]
      [Route("ShopInfo")]
      public ObjectResult GetShopByMerchantId ([FromHeader] string merchantId)
      {
        Shop shop = _query.getShopByMerchantId(merchantId);

        if(shop == null)
        {
          return new BadRequestObjectResult("merchant no shop");
        }

        if(shop.IsIdentitied == false)
        {
          return new BadRequestObjectResult("identity yourself first");
        }

        var merchantShop = new MerchantShopViewModel(shop.PkId.ToString(), shop.Name, shop.Province, shop.City, shop.District, shop.Location,
                                  shop.Type, shop.Tel, shop.RegisterId.ToString(), shop.Pic, shop.IsIdentitied);
      
        return new OkObjectResult(merchantShop);
      }

/*       [HttpGet]
      [Route("ShopLists")]
      public ActionResult GetShopListByShopType([FromQuery] int shopType)
      {
        List<Shop> shopList = _query.getShopListByShopType(shopType);

        if(shopList == null) return BadRequest();

        else return Ok(shopList);
      } */

      [HttpGet]
      [Route("ShopBasicList")]
      public ActionResult GetShopBasicListByShopTypeAndCity([FromQuery]string province, string city, int shopType)
      {
        List<Shop> shopList  = _query.getShopListByShopTypeAndCity(province, city, shopType);

        if(shopList == null) return BadRequest();

        List<ShopBasicViewModel> shopBasicList = new List<ShopBasicViewModel>();

        foreach(var i in shopList) {
          shopBasicList.Add(new ShopBasicViewModel(i.PkId.ToString(), i.Name, i.Province, i.City, i.District, i.Location, i.Pic));
        }

        return Ok(shopBasicList);
      }

      [HttpGet]
      [Route("ShopListOfCity")]
      public ActionResult GetShopListOfCity([FromQuery]string province, string city)
      {
        List<Shop> shopList = _query.getShopListByCity(province, city);
      
        if(shopList == null) return BadRequest();

        List<ShopBasicViewModel> shopBasicList = new List<ShopBasicViewModel>();

        foreach(var i in shopList) {
          shopBasicList.Add(new ShopBasicViewModel(i.PkId.ToString(), i.Name, i.Province, i.City, i.District, i.Location, i.Pic));
        }

        return Ok(shopBasicList);
      }

      [HttpGet]
      [Route("MerchantIfIdentity")]
      public ActionResult JudgeIfIdentity([FromQuery] string shopName)
      {
        Shop shop = _query.getShopByName(shopName);

        if(shop.IsIdentitied == true) {
          return Ok("true");
        } else {
          return Ok("true");
        }
      }

      [HttpGet]
      [Route("IfSetGB")]
      public ActionResult JudgeIfGB([FromHeader]string merchantId)
      {
        Shop shop = _query.getShopByMerchantId(merchantId);

        if(shop == null) return BadRequest();

        else return Ok(shop.GroupBuying);
      }

      [HttpPost]
      [Route("SetGroupBuying")]
      public ActionResult SetGB([FromBody] SetGBCommand command) 
      {
        int result = _mediator.Send(command, default(CancellationToken)).GetAwaiter().GetResult();

        if(result == 0) return BadRequest("设置团购服务有误");
        else return Ok("团购服务申请成功");
      }

      [HttpPost]
      [Route("UploadShopImg")]
      public ActionResult UploadShopImg()
      {
        if(Request.Form.Files.Count != 0)
        {
          var stream = Request.Form.Files[0].OpenReadStream();

          byte[] bytes = new byte[stream.Length]; 

          int readNum = stream.Read(bytes, 0, bytes.Length);

          string merchantId = Request.Form["merchantId"];

          string imgLocation = _mediator.Send(new UploadImgCommand(merchantId, Request.Form.Files[0].FileName, bytes)).GetAwaiter().GetResult();
        
          if(imgLocation == "")
          {
            return new StatusCodeResult(400);
          }  

          return Ok(imgLocation);
        }

        return new StatusCodeResult(400);
      }

      [HttpPost]
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [Route("EditShop")]
      public ActionResult EditShop ([FromBody] EditShopCommand command)
      {
        Shop newShop = _mediator.Send(command).GetAwaiter().GetResult();

        if(newShop == null) return BadRequest();

        return Ok(newShop);
      }

/*       [HttpGet]
      [Route("Shops")]
      public ActionResult<List<ShopsViewModel>> GetShops ()
      {
        List<ShopsViewModel> shopsModel = new List<ShopsViewModel>();
        List<Shop> shops = _query.getShops();

        foreach(var shop in shops)
        {
          shopsModel.Add(new ShopsViewModel(shop.PkId.ToString(), shop.Name, shop.Province, shop.City, shop.District
                                             , shop.Location, shop.Type, shop.Tel, shop.RegisterId.ToString(), shop.Pic));
        }

        return shopsModel;
      } */
    }
}