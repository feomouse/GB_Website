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
using System.Linq;

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
      public ActionResult<IList<ShopType>> GetShopTypies ()
      {
        return Ok( _query.getShopTypes().Select(t => new {PkId = t.PkId, Name = t.Name, Img = t.Img}));
      }  

      [HttpPost]
      [Route("AddShopType")]
      public ActionResult AddShopType([FromBody] AddShopTypeCommand command)
      {
        return Ok(_mediator.Send(command).GetAwaiter().GetResult());
      }

      [HttpDelete]
      [Route("DeleteShopType")]
      public ActionResult DeleteShopType([FromHeader] string shopTypeId)
      {
        return Ok(_mediator.Send(new DeleteShopTypeCommand(shopTypeId)).GetAwaiter().GetResult());
      }

      [HttpPost]
      [Route("SetShopType")]
      public ActionResult SetShopType([FromBody] EditShopTypeCommand command)
      {
        return Ok(_mediator.Send(command).GetAwaiter().GetResult());
      }

      [HttpPost]
      [Route("GetShopsByMerchantIds")]
      public ActionResult GetShopsByMerchantIds([FromBody] IList<string> merchantIds)
      {
        return Ok(_query.getShopsByMerchantIds(merchantIds));
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

        //_publisher.Publish(new ShopIsCreatedIntergrationEvent(createdShop.PkId, new Guid(shop.Manager)));

        return new CreatedResult("", new CreatedShopViewModel(createdShop.PkId.ToString()));
      }

      [HttpGet]
      [Route("GetShops")]
      public ObjectResult GetShopsByNameAndCity ([FromQuery] string name, string province, string city)
      {
        IList<Shop> shops = _query.getShopsByNameAndCity(name, province ,city);

        if(shops == null)
        {
          return new BadRequestObjectResult("no shop");
        }

        return new OkObjectResult(shops.Select(shop => new {PkId=shop.PkId.ToString(), Name=shop.Name, Province=shop.Province, City=shop.City, District=shop.District, Location=shop.Location, Tel=shop.Tel, RegisterId=shop.RegisterId.ToString()}));
      }

      [HttpGet]
      [Route("SearchShop")]
      public ObjectResult GetShopByNameAndCity ([FromQuery] string name, string province, string city)
      {
        Shop shop = _query.getShopByNameAndCity(name, province ,city);

        if(shop == null)
        {
          return new BadRequestObjectResult("no shop");
        }

        var result = new SearchShopViewModel(shop.PkId.ToString(), shop.Name, shop.Province, shop.City, shop.District, shop.Location, shop.Tel , shop.Type, shop.RegisterId.ToString());
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
                                  shop.Type, shop.Tel, shop.RegisterId.ToString(), shop.IsIdentitied);
      
        return new OkObjectResult(merchantShop);
      }

      [HttpGet]
      [Route("ShopName")]
      public ActionResult GetShopNameByShopId ([FromHeader] string shopId)
      {
        Shop shop = _query.getShopByShopId(shopId);
        if(shop == null) return BadRequest();
        else return Ok(shop.Name);
      }

/*       [HttpGet]
      [Route("ShopLists")]
      public ActionResult GetShopListByShopType([FromQuery] int shopType)
      {
        List<Shop> shopList = _query.getShopListByShopType(shopType);

        if(shopList == null) return BadRequest();

        else return Ok(shopList);
      } */
/* 
      [HttpGet]
      [Route("ShopBasicList")]
      public ActionResult GetShopBasicListByShopTypeAndCity([FromQuery]string province, string city, int shopType, int page)
      {
        List<Shop> shopList  = _query.getShopListByShopTypeAndCity(province, city, shopType, page);

        if(shopList == null) return BadRequest();

        List<ShopBasicViewModel> shopBasicList = new List<ShopBasicViewModel>();

        foreach(var i in shopList) {
          shopBasicList.Add(new ShopBasicViewModel(i.PkId.ToString(), i.Name, i.Province, i.City, i.District, i.Location));
        }

        return Ok(shopBasicList);
      }

      [HttpGet]
      [Route("TotalShopsCount")]
      public ActionResult GetTotalShopsCount([FromQuery]string province, string city, int shopType)
      {
        return Ok(_query.getShopsTotalCount(province, city, shopType));
      }
*/
      [HttpGet]
      [Route("ShopListOfCity")]
      public ActionResult GetShopListOfCity([FromQuery]string province, string city)
      {
        List<Shop> shopList = _query.getShopListByCity(province, city);
      
        if(shopList == null) return BadRequest();

        List<ShopBasicViewModel> shopBasicList = new List<ShopBasicViewModel>();

        foreach(var i in shopList) {
          shopBasicList.Add(new ShopBasicViewModel(i.PkId.ToString(), i.Name, i.Province, i.City, i.District, i.Location));
        }

        return Ok(shopBasicList);
      }

      [HttpPost]
      [Route("ShopListByShopIdList")]
      public ActionResult GetShopListByShopIdList([FromBody] List<GetShopListByShopIdListCommand> shopIdList)
      {
        List<ShopNameAndLocationViewModel> result = new List<ShopNameAndLocationViewModel>();

        foreach(var i in shopIdList) 
        {
          Shop shop = _query.getShopByShopId(i.ShopId);
          result.Add(new ShopNameAndLocationViewModel(shop.Name, shop.Province+shop.City+shop.District+shop.Location));
        }

        return Ok(result);
      }

      [HttpGet]
      [Route("MerchantIfIdentity")]
      public ActionResult JudgeIfIdentity([FromQuery] string shopName)
      {
        Shop shop = _query.getShopByName(shopName);

        if(shop.IsIdentitied == true) {
          return Ok("true");
        } else {
          return Ok("false");
        }
      }

      [HttpGet]
      [Route("IfSetGB")]
      public ActionResult JudgeIfGB([FromHeader]string shopId)
      {
        Shop shop = _query.getShopByShopId(shopId);

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
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [Route("EditShop")]
      public ActionResult EditShop ([FromBody] EditShopCommand command)
      {
        Shop newShop = _mediator.Send(command).GetAwaiter().GetResult();

        if(newShop == null) return BadRequest();

        return Ok(new {pkId= newShop.PkId, name= newShop.Name, province= newShop.Province, 
                     city= newShop.City, district= newShop.District, location= newShop.Location, type= newShop.ShopTypePkId, tel= newShop.Tel, 
                     isIdentitied= newShop.IsIdentitied, groupBuying= newShop.GroupBuying,
                     ownMoney= newShop.OwnMoney, workingTime= newShop.WorkingTime});
      }

      [HttpGet]
      [Route("GetShopsByMerchantId")]
      public ActionResult GetShopsByMerchantId ([FromHeader] string merchantId)
      {
        var shops = _query.getShopsByMerchantId(merchantId);
        return Ok(shops.Select(s => new {pkId= s.PkId, name= s.Name, province= s.Province, 
                     city= s.City, district= s.District, location= s.Location, type= s.ShopTypePkId, tel= s.Tel, isIdentitied= s.IsIdentitied, groupBuying= s.GroupBuying,
                     ownMoney= s.OwnMoney, workingTime= s.WorkingTime}));
      }

      [HttpGet]
      [Route("GetShopImgs")]
      public ActionResult GetShopImgs([FromHeader] string shopId)
      {
        return Ok(_query.getShopImgs(shopId).Select(sm => new {pkId = sm.MShopId, img = sm.Img}));
      }

      [HttpPost]
      [Route("SetShopImg")]
      public ActionResult SetShopImg([FromBody] AddShopImgCommand command)
      {
        var result = _mediator.Send(command).GetAwaiter().GetResult();

        if(result == 0) return BadRequest();

        return Ok();
      }

      [HttpGet]
      [Route("GetShopsByDistrictAndType")]
      public ActionResult GetShopsByDistrictAndType([FromQuery]string province, [FromQuery]string city, [FromQuery]string district, [FromHeader]string shopTypeId, [FromHeader]int page)
      {
        var shops = _query.getShopsByDistrictAndType(province, city, district, shopTypeId, page);

        var shopViews = new List<RandomShopViewModel>();

        foreach(var s in shops)
        {
            var img = "";
            var imgs = _query.getShopImgs(s.PkId.ToString());
            if(imgs.Count() != 0) {
              img = imgs[0].Img; 
            }
            
            shopViews.Add(new RandomShopViewModel(s.PkId.ToString(), s.Name, s.Province, s.City, s.District, s.Location,
                            s.Tel, s.ShopTypePkId.ToString(), s.RegisterId.ToString(), img, s.WorkingTime));
        }
        return Ok(shopViews);
      }

      [HttpGet]
      [Route("GetRandomShops")]
      public ActionResult GetRandomShopsByCityAndType([FromQuery]string province, [FromQuery]string city, [FromHeader]string shopTypeId)
      {
        var shops = _query.getRandomShopsByCityAndType(province, city, shopTypeId);
        
        var shopViews = new List<RandomShopViewModel>();

        foreach(var s in shops)
        {
            var img = "";
            var imgs = _query.getShopImgs(s.PkId.ToString());
            if(imgs.Count() != 0) {
              img = imgs[0].Img; 
            }

            shopViews.Add(new RandomShopViewModel(s.PkId.ToString(), s.Name, s.Province, s.City, s.District, s.Location,
                            s.Tel, s.ShopTypePkId.ToString(), s.RegisterId.ToString(), img, s.WorkingTime));
        }
        return Ok(shopViews);
      }

      [HttpGet]
      [Route("GetShopsNumByDistrictAndShopType")]
      public ActionResult GetShopsNumByDistrictAndShopType([FromQuery]string province, [FromQuery]string city, 
                                                [FromQuery]string district, [FromHeader]string shopTypeId)
      {
        return Ok(_query.getShopsNumByDistrictAndShopType(province, city, district, shopTypeId));
      }

      [HttpPost]
      [Route("IncreaseVisitNum")]
      public ActionResult IncreaseVisitNum([FromBody] IncreaseVisitNumCommand command)
      {
        return Ok(_mediator.Send(command).GetAwaiter().GetResult());
      }

      [HttpPost]
      [Route("IncreaseMonthSell")]
      public ActionResult IncreaseMonthSell([FromBody] IncreaseMonthSellCommand command)
      {
        return Ok(_mediator.Send(command).GetAwaiter().GetResult());
      }

      [HttpGet]
      [Route("GetVisitNum")]
      public ActionResult GetVisitNum([FromHeader] string shopId, [FromQuery] string year)
      {
        return Ok(_query.getVisitNumByYear(shopId, year));
      }

      [HttpGet]
      [Route("GetMonthSell")]
      public ActionResult GetMonthSell([FromHeader] string shopId, [FromQuery] string year)
      {
        return Ok(_query.getMonthSellByYear(shopId, year));
      }
    }
}