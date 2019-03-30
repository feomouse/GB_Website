using MediatR;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System.Threading;
using GB_Project.Services.MerchantService.MerchantAPI.Query;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AddIdentityCommandHandler : IRequestHandler<AddIdentityCommand, MerchantBasic>
  {
    private IMerchantRepository _repo;

    private IMerchantQuery _query;

    public AddIdentityCommandHandler(IMerchantRepository repo, IMerchantQuery query)
    {
      _repo = repo;

      _query = query;
    }

    public Task<MerchantBasic> Handle (AddIdentityCommand command, CancellationToken cancellaitonToken)
    {
      var merchant = _query.GetMerchantBasicByMerchantId(command.MerchantId);

      var merchantIdentity = new MerchantIdentity(command.IdentityName, command.IdentityNum, command.IdentityImgF, command.IdentityImgB, command.LicenseImg, 
                      command.LicenseCode, command.LicenseName, command.LicenseOwner, command.AvailableStartTime, 
                      command.AvailableTime, command.Tel);
      if(_repo.AddIdentity(merchant, merchantIdentity).GetAwaiter().GetResult() != 0)
      {
        return Task.FromResult(merchant);
      }

      return Task.FromResult((MerchantBasic)null);
    }
  }
}