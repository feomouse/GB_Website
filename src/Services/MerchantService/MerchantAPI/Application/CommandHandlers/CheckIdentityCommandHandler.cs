using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.CommandHandlers
{
  public class CheckIdentityCommandHandler : IRequestHandler<CheckIdentityCommand, int>
  {
    private IMerchantRepository _repo;

    public CheckIdentityCommandHandler(IMerchantRepository repo)
    {
      _repo = repo;
    }

    public Task<int> Handle (CheckIdentityCommand command, CancellationToken cannellationToken)
    {
      if(_repo.GetMerhcntBasicByMerchantId(command.MerchantId).IsChecked != command.CheckResult)
      {
        return _repo.CheckMerchantIdentity(command.MerchantId, command.CheckResult);
      }
      return Task.FromResult(1);
    }
  }
}