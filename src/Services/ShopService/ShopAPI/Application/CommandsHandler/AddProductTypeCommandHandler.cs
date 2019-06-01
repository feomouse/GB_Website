using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommand, int>
    {
      private IShopRepository _repository;

      private IShopQuery _query;

      public AddProductTypeCommandHandler ( IShopRepository repository, IShopQuery query )
      {
        _repository = repository;

        _query = query;
      }

      public Task<int> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
      {
        var shop = _query.getShopByShopId(request.ShopId);
        ProductType productType = new ProductType(shop, request.TypeName);

        return Task.FromResult(_repository.CreateShopProductType(productType));      
      }
    }
}