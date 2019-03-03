using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;

namespace GB_Project.Services.MerchantService.MerchantAPI.Query
{
  public interface IMerchantQuery
  {
    MerchantBasic GetMerchantBasicByMerchantId(Guid merchantId);
  }
}