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

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/shop")]
    public class ShopController : ControllerBase
    {
      private IMediator _mediator;
      private IShopQuery _query;

      public ShopController ( IMediator mediator, IShopQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      [Route("ShopTypies")]
      public ActionResult<List<ShopTypesViewModel>> GetShopTypies ()
      {
        var shopTypes = new List<ShopTypesViewModel>();
        shopTypes.Add(new ShopTypesViewModel(ShopType.beauty.Id, ShopType.beauty.Name));
        shopTypes.Add(new ShopTypesViewModel(ShopType.entertain.Id, ShopType.entertain.Name));
        shopTypes.Add(new ShopTypesViewModel(ShopType.food.Id, ShopType.food.Name));

        return shopTypes;
      }  

      [HttpGet]
      [Route("ShopInfo")]
      public ActionResult GetShopByName ([FromQuery] string name)
      {
        Shop shop = _query.getShopByName(name);

        if(shop == null)
        {
          return new OkObjectResult("");
        }

        return new OkObjectResult(shop);
      }

      [HttpGet]
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

        int num = _mediator.Send(shop).GetAwaiter().GetResult();

        if (num == 0)
        {
          return new StatusCodeResult(400);
        }

        return new StatusCodeResult(201);
      }
    }
}