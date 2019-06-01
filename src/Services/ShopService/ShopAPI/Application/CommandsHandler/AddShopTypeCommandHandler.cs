using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddShopTypeCommandHandler : IRequestHandler<AddShopTypeCommand, int>
    {
      private IShopRepository _repository;

      private IShopQuery _query;

      public AddShopTypeCommandHandler ( IShopRepository repository, IShopQuery query )
      {
        _repository = repository;

        _query = query;
      }

      public Task<int> Handle(AddShopTypeCommand request, CancellationToken cancellationToken)
      {
        ShopType productType = new ShopType(request.TypeName, request.Img);

        return Task.FromResult(_repository.CreateShopType(productType));      
      }
    }
}