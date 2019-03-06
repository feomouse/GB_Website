using MediatR;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System.Threading;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AddIdentityCommandHandler : IRequestHandler<AddIdentityCommand, MerchantBasic>
  {
    private IMerchantRepository _repo;
    public AddIdentityCommandHandler(IMerchantRepository repo)
    {
      _repo = repo;
    }

    public Task<MerchantBasic> Handle (AddIdentityCommand command, CancellationToken cancellaitonToken)
    {
      if(_repo.AddIdentity(command.merchantBasic, command.merhcantIdentity).GetAwaiter().GetResult() == 1)
      {
        return Task.FromResult(command.merchantBasic);
      }

      return Task.FromResult((MerchantBasic)null);
    }
  }
}