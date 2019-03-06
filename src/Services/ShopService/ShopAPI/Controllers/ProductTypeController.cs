using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopAPI.ViewModels;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/productType")]
    public class ProductTypeController : ControllerBase
    {
      private IMediator _mediator;
      private IShopQuery _query;

      public ProductTypeController ( IMediator mediator, IShopQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      [Route("getProductTypes")]
      public ActionResult<List<ProductTypesViewModel>> getShopProductTypesByShopName ([FromQuery]string shopName)
      {
        List<ProductTypesViewModel> types = new List<ProductTypesViewModel>();
        List<ProductType> productTypes = _query.getShopProductTypesByShopName(shopName);

        foreach(var type in productTypes)
        {
          types.Add(new ProductTypesViewModel(type.PkId.ToString(), type.ShopId.ToString(), type.TypeName));
        }
        return Ok(types);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("add")]
      public ActionResult AddProductType ([FromBody]AddProductTypeCommand productType )
      {
        int num = _mediator.Send(productType).GetAwaiter().GetResult();

        if ( num == 0)
        {
          return new StatusCodeResult(400);
        }

        return new StatusCodeResult(201);
      } 

    }
}