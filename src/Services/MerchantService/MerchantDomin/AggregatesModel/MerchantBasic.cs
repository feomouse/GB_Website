using System;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public class MerchantBasic : Entity
  {
    public Guid AuthPkId { get; private set; }

    public Guid ShopId { get; private set; }
    
    public bool IsChecked { get; private set; }

    public MerchantBasic ()
    {
      IsChecked = false;
    }

    public MerchantBasic( Guid id )
    {
      AuthPkId = id;
      IsChecked = false;
    }

    public void SetShopId( Guid shopId )
    {
      ShopId = shopId;
    }

/*     public void SetIdentity(MerchantIdentity merchantIdentity)
    {
      Identity = merchantIdentity;
    } */

    public void SetIsChecked(bool isChecked)
    {
      IsChecked = isChecked;
    }
  }   
}