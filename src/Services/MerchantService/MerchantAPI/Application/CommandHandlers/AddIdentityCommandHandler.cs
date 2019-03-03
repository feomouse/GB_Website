using MediatR;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System.Threading;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AddIdentityCommandHandler : IRequestHandler<AddIdentityCommand, int>
  {
    private IMerchantRepository _repo;
    public AddIdentityCommandHandler(IMerchantRepository repo)
    {
      _repo = repo;
    }

    public Task<int> Handle (AddIdentityCommand command, CancellationToken cancellaitonToken)
    {
      return _repo.AddIdentity(command.merchantBasic, command.merhcantIdentity);
    }
  }
}