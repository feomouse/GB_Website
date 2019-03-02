using System;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public class MerchantBasic : Entity
  {
    public Guid AuthPkId { get; private set; }

    public Guid ShopId { get; private set; }

    public MerchantIdentity Identity { get; private set; }

    public MerchantBasic ()
    {

    }

    public MerchantBasic( Guid id )
    {
      AuthPkId = id;
    }

    public void SetShopId( Guid shopId )
    {
      ShopId = shopId;
    }
  }   
}