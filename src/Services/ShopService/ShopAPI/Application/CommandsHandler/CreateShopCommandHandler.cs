using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, Shop>
    {
      private IShopRepository _repository;

      public CreateShopCommandHandler ()
      {

      } 
      public CreateShopCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }
      public Task<Shop> Handle(CreateShopCommand request, CancellationToken cancellationToken)
      {
        Shop shop = new Shop(request.Name, request.Province, request.City, request.District, request.Location, request.Type, request.Tel, new Guid(request.Manager), request.Pic);

        if(_repository.CreateShop(shop) != 0)
        {
          return Task.FromResult(shop);
        }

        return Task.FromResult((Shop)null);
      }
    }
}