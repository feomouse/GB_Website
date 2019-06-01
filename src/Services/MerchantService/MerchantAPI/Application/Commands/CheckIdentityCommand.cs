using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.Commands
{
  public class CheckIdentityCommand : IRequest<int>
  {
    public string MerchantId { get; set; }

    public string ShopId { get; set; }

    public bool CheckResult { get; set; }

    public CheckIdentityCommand(string merchantId, string shopId, bool checkResult)
    {
      MerchantId = merchantId;
      ShopId = shopId;
      CheckResult = checkResult;
    }
  }
}