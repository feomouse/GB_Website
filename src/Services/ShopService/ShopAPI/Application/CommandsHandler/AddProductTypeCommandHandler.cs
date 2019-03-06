using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommand, int>
    {
      private IShopRepository _repository;

      public AddProductTypeCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<int> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
      {
        var shop = _repository.GetShopByShopId(request.ShopId);
        ProductType productType = new ProductType(shop, request.TypeName);

        return Task.FromResult(_repository.CreateShopProductType(productType));      
      }
    }
}