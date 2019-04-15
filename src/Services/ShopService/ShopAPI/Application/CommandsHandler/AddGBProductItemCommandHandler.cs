/* using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddGBProductItemCommandHandler : IRequestHandler<AddGBProductItemCommand, int>
    {
      private IShopRepository _repository;

      public AddGBProductItemCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public async Task<int> Handle(AddGBProductItemCommand request, CancellationToken cancellationToken)
      {
        GBProductItem gbproductitem = new GBProductItem(request.GbProductId, request.GbItemName, request.GbItemImg, request.GbItemPrice);

        _repository.AddGBProductItem(gbproductitem);      
              
        return await _repository.Save();
      }
    }
} */