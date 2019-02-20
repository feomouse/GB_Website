using GB_project.Services.ShopService.ShopDomin.SeedWork;
using System;

namespace GB_project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class ShopMerchant : Entity
    {
      public Guid MerchantId { get; private set; }

      public Guid ShopId { get; private set; }

      public bool IsRegister { get; private set; }

      public ShopMerchant ()
      {

      } 

      public ShopMerchant ( Guid merchantId, Guid shopId, bool isRegister)
      {
        MerchantId = merchantId;
        ShopId = shopId;
        IsRegister = isRegister;
      }

      public void AddShopMerchant ( ShopMerchant shopMercant )
      {
      }
    }
}