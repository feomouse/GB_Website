using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class CheckIdentityCommand : IRequest<int>
  {
    public string MerchantId { get; set; }

    public bool CheckResult { get; set; }

    public CheckIdentityCommand(string merchantId, bool checkResult)
    {
      MerchantId = merchantId;
      CheckResult = checkResult;
    }
  }
}