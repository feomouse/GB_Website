using System;
using GB_project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_project.Services.MerchantService.MerchantDomin.Aggregateroot
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