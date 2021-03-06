using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
    public class AddMerchantCommandHandler : IRequestHandler<AddMerchantCommand, int>
    {
      private IShopRepository _repository;

      public AddMerchantCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public async Task<int> Handle(AddMerchantCommand request, CancellationToken cancellationToken)
      {
        ShopMerchant merchant = new ShopMerchant(request.MerchantId, request.ShopId, request.IsRegister);

        _repository.AddMerchant(merchant);      
              
        return await _repository.Save();
      }
    }
}