/* using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddGBProductCommandHandler : IRequestHandler<AddGBProductCommand, int>
    {
      private IShopRepository _repository;

      public AddGBProductCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public async Task<int> Handle(AddGBProductCommand request, CancellationToken cancellationToken)
      {
        GBProduct gbproduct = new GBProduct(request.ShopId, request.ProductName, request.OrinPrice, request.Price, request.Quantity, request.VailSDate, request.VailEDate, request.VailTime, request.Img, request.Remark);

        _repository.AddGBProduct(gbproduct);      
              
        return await _repository.Save(); 
      }
    }
} */