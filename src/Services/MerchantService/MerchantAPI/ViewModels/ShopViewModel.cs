using System.Runtime.Serialization;

namespace GB_Project.Services.MerchantService.MerchantAPI.ViewModels
{
  [DataContract]
  public class ShopViewModel
  {
    [DataMember]
    public string MerchantId { get; set; }

    [DataMember]
    public string ShopId { get; set; }

    public ShopViewModel(string merchantId, string shopId)
    {
      MerchantId = merchantId;
      ShopId = shopId;
    }
  }
}