using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;
using System.Collections.Generic;

namespace GB_Project.Services.MerchantService.MerchantAPI.Query
{
  public interface IMerchantQuery
  {
    MerchantBasic GetMerchantBasicByMerchantId(string merchantId);

    MerchantIdentity GetMerchantIdentityByIdentityId(string identityId);

    MerchantIdentity GetMerchantIdentityByMerchantId(string merchantId);

    List<MerchantBasic> GetMerchantBasicListNotChecked(int page);

    List<MerchantBasic> GetMerchantBasics(int page);
  }
}