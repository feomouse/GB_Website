using System;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.CommandHandlers
{
  public class AddShopCommandHandler : IRequestHandler<AddShopCommand, int>
  {
    private IMerchantRepository _repo;

    private IMerchantQuery _query;

    public AddShopCommandHandler(IMerchantRepository repo, IMerchantQuery query)
    {
      _repo = repo;

      _query = query;
    }

    public Task<int> Handle (AddShopCommand command, CancellationToken cannellationToken)
    {
      MerchantBasic merchantBasic = _query.GetMerchantBasicByMerchantId(command.MerchantId);
 
       if(merchantBasic == null)
       {
         return Task.FromResult(0);
       } 
      return _repo.AddShopIdToMerchant(merchantBasic, new Guid(command.ShopId));
    }
  }
}