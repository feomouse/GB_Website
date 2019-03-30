/* using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
      private IShopRepository _repository;

      public AddProductCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
      {
        var productType = _repository.GetShopProductTypeByShopProductTypeId(request.ProductType);
        Product product = new Product(request.ProductName, productType, request.ProductImg, request.ProductPrice, request.MSellNum, request.PraiseNum, request.IsDisplay);

        return Task.FromResult(_repository.AddShopProduct(product));      
      }
    }
} */