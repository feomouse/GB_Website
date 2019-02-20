using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
      private IShopRepository _repository;

      public AddProductCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
      {
        Product product = new Product(request.ShopId, request.ProductName, request.ProductType, request.ProductImg, request.ProductPrice, request.MSellNum, request.PraiseNum, request.IsDisplay);

        _repository.AddProduct(product);      
              
        return await _repository.Save();
      }
    }
}