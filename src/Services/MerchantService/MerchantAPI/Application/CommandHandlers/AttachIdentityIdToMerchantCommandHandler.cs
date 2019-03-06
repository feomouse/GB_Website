using MediatR;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System.Threading;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AttachIdentityIdToMerchantCommandHandler : IRequestHandler<AttachIdentityIdToMerchantCommand, int>
  {
    private IMerchantRepository _repo;
    public AttachIdentityIdToMerchantCommandHandler(IMerchantRepository repo)
    {
      _repo = repo;
    }

    public Task<int> Handle (AttachIdentityIdToMerchantCommand command, CancellationToken cancellaitonToken)
    {
      return  _repo.AddIdentityIdToMerchant(command.merchantBasic, command.merhcantIdentity);
    }
  }
}