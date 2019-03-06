using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, int>
    {
      private IShopRepository _repository;

      public CreateShopCommandHandler ()
      {

      } 
      public CreateShopCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }
      public Task<int> Handle(CreateShopCommand request, CancellationToken cancellationToken)
      {
        Shop shop = new Shop(request.Name, request.Province, request.City, request.District, request.Location, request.Type, request.Tel, request.Manager, request.Pic);

        return Task.FromResult(_repository.CreateShop(shop));
      }
    }
}