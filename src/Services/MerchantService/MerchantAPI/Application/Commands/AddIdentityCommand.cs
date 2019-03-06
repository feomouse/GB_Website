using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class AddIdentityCommand : IRequest<MerchantBasic>
  {
    public MerchantBasic merchantBasic { get; set; }

    public MerchantIdentity merhcantIdentity { get; set; }

    public AddIdentityCommand (MerchantBasic basic, MerchantIdentity identity)
    {
      merchantBasic = basic;

      merhcantIdentity = identity;
    }
  }
}