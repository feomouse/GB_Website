using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Query;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.CommandHandlers
{
  public class CheckIdentityCommandHandler : IRequestHandler<CheckIdentityCommand, int>
  {
    private IMerchantRepository _repo;

    private IMerchantQuery _query;

    public CheckIdentityCommandHandler(IMerchantRepository repo, IMerchantQuery query)
    {
      _repo = repo;

      _query = query;
    }

    public Task<int> Handle (CheckIdentityCommand command, CancellationToken cannellationToken)
    {
      if(_query.GetMerchantShop(command.MerchantId, command.ShopId).IsChecked != command.CheckResult)
      {
        return _repo.CheckMerchantIdentity(command.MerchantId, command.ShopId, command.CheckResult);
      }
      return Task.FromResult(1);
    }
  }
}