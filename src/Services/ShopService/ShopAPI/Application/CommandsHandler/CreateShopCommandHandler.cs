using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, Shop>
    {
      private IShopRepository _repository;

      private IShopQuery _query; 

      public CreateShopCommandHandler ()
      {

      } 
      public CreateShopCommandHandler ( IShopRepository repository, IShopQuery query )
      {
        _repository = repository;

        _query = query;
      }
      public Task<Shop> Handle(CreateShopCommand request, CancellationToken cancellationToken)
      {
        Shop shop = new Shop(request.Name, request.Province, request.City, request.District, request.Location, request.Tel, request.WorkingTime);

        shop.SetType(_query.getShopTypeByPkId(request.Type));

        if(_repository.CreateShop(shop) != 0)
        {
         // _repository.AddShopToShopType(request.Type, shop);
          return Task.FromResult(shop);
        }

        return Task.FromResult((Shop)null);
      }
    }
}