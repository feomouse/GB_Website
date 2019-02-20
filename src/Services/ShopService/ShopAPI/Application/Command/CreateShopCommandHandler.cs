using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, int>
    {
      private IShopRepository _repository;

 /*      public CreateShopCommandHandler ()
      {

      } */
      public CreateShopCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }
      public async Task<int> Handle(CreateShopCommand request, CancellationToken cancellationToken)
      {
        Shop shop = new Shop(request.Name, request.Province, request.City, request.District, request.Location, request.Type, request.Tel, request.Manager, request.Pic);

        _repository.CreateShop(shop);
        return await _repository.Save();
      }
    }
}