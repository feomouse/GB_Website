using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;
using System.Collections.Generic;

namespace GB_Project.Services.MerchantService.MerchantAPI.Query
{
  public interface IMerchantQuery
  {
    MerchantBasic GetMerchantBasicByMerchantId(string merchantId);

    MerchantIdentity GetMerchantIdentityByIdentityId(string identityId);

    IList<MerchantIdentity> GetMerchantIdentityByMerchantId(string merchantId);

    List<MerchantShop> GetMerchantShopListNotChecked(int page);

    int GetMerchantShopListNotCheckedNum();

    List<MerchantBasic> GetMerchantBasics(int page);

    IList<MerchantShop> GetMerchantShops(string merchantId);

    MerchantShop GetMerchantShop(string merchantId, string shopId);

    MerchantIdentity GetMerchantIdentityByMIdAndSId(string merchantId, string shopId);

    int GetMerchantNum();
  }
}