using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AttachIdentityIdToMerchantCommand : IRequest<int>
  {
    public MerchantBasic merchantBasic { get; set; }

    public MerchantIdentity merhcantIdentity { get; set; }

    public AttachIdentityIdToMerchantCommand (MerchantBasic basic, MerchantIdentity identity)
    {
      merchantBasic = basic;

      merhcantIdentity = identity;
    }
  }
}