using System;
using System.Collections.Generic;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public class MerchantBasic : Entity
  {
    public Guid AuthPkId { get; private set; }

    public List<MerchantShop> Shops{get; private set; }

    public MerchantBasic ()
    {
    }

    public MerchantBasic( Guid id )
    {
      AuthPkId = id;
    }

/*     public void SetIdentity(MerchantIdentity merchantIdentity)
    {
      Identity = merchantIdentity;
    } */
    public void SetShops()
    {
      Shops = new List<MerchantShop>();
    }
  }   
}