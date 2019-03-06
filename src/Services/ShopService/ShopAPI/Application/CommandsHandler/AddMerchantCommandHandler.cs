/* using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
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
} */