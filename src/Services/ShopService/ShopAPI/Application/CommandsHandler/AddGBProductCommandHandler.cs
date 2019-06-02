using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddGBProductCommandHandler : IRequestHandler<AddGBProductCommand, int>
    {
      private IShopRepository _repository;

      public AddGBProductCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<int> Handle(AddGBProductCommand request, CancellationToken cancellationToken)
      {
        ProductType productType = _repository.GetProductTypeByProductTypeId(request.ProductTypeId);

        GBProduct gbproduct = new GBProduct(request.ProductName, double.Parse(request.OrinPrice), double.Parse(request.Price), request.Quantity, Convert.ToDateTime(request.VailSDate), Convert.ToDateTime(request.VailEDate), request.VailTime, request.Remark, productType);
    
        var result = _repository.AddGBProduct(gbproduct);
        return Task.FromResult(result);               
      }
    }
}