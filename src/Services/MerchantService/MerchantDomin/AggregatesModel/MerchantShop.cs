using System;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public class MerchantShop 
  {
    public Guid MBasicId {get; private set;}
    public MerchantBasic MBasic{ get; private set; }

    public Guid ShopId {get; private set; }

    public Guid? MIdentityId { get; private set; }

    public MerchantIdentity MIdentity { get; private set; }

    public bool IsChecked { get; private set; }

    public MerchantShop(Guid mBasicId, Guid shopId)
    {
      MBasicId = mBasicId;
      ShopId = shopId;
      IsChecked = false;
    }

    public MerchantShop(MerchantBasic mBasic, Guid shopId)
    {
      MBasic = mBasic;
      ShopId = shopId;
      IsChecked = false;
    }

    public void SetIsChecked(bool isChecked)
    {
      IsChecked = isChecked;
    }
  }
}