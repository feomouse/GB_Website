using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopAPI.ViewModels;

namespace GB_Project.Services.ShopService.ShopAPI.Controllers
{
    [Route("v1/api/product")]
    public class ProductController : ControllerBase
    {
      private IMediator _mediator;
      private IShopQuery _query;

      public ProductController ( IMediator mediator, IShopQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      [Route("GetProduct")]
      public ActionResult<Product> GetProductByName ([FromQuery]string name)
      {
        Product product = _query.getProductByName(name);

        return Ok(product);
      }

      [HttpGet]
      [Route("GetProducts")]
      public ActionResult<List<ProductsViewModel>> GetProductsByShopName ([FromQuery]string shopName)
      {
        var products = _query.GetShopProductsByShopName(shopName);
        List<ProductsViewModel> viewModels = new List<ProductsViewModel>();

        foreach(var product in products)
        {
          viewModels.Add(new ProductsViewModel(product.PkId, product.ProductName, product.ProductTypeId, product.ProductImg, 
                               product.ProductPrice, product.MSellNum, product.PraiseNum, product.IsDisplay));
        }

        return Ok(viewModels);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("create")]
      public ActionResult AddProduct ([FromBody]AddProductCommand product )
      {
        int num = _mediator.Send(product).GetAwaiter().GetResult();

        if ( num == 0)
        {
          return new StatusCodeResult(400);
        }

        return  new StatusCodeResult(201);
      }
    }
}