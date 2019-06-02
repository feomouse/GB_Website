using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class UpdateGBProductCommandHandler : IRequestHandler<UpdateGBProductCommand, GBProduct>
    {
      private IShopRepository _repository;

      public UpdateGBProductCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<GBProduct> Handle(UpdateGBProductCommand request, CancellationToken cancellationToken)
      {
        ProductType pt = _repository.GetProductTypeByProductTypeId(request.ProductTypeId);
        GBProduct newGB = _repository.UpdateGBProducts(new GBProduct(new Guid(request.GBProductId), request.ProductName, double.Parse(request.OrinPrice), double.Parse(request.Price), request.Quantity, 
                                                   Convert.ToDateTime(request.VailSDate), Convert.ToDateTime(request.VailEDate), request.VailTime, 
                                                   request.Remark, pt));

        return Task.FromResult(newGB);
      }
    }
}