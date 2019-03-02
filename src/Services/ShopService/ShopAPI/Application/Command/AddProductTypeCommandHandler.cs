/* using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Command
{
    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommand, int>
    {
      private IShopRepository _repository;

      public AddProductTypeCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public async Task<int> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
      {
        ProductType productType = new ProductType(request.ShopId, request.TypeName);

        _repository.AddProductType(productType);      
              
        return await _repository.Save();
      }
    }
} */