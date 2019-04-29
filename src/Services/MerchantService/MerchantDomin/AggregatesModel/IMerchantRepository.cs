using System.Threading.Tasks;
using System;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;
using System.Collections.Generic;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public interface IMerchantRepository : IRepository
  {
    Task<int> CreateMerchantBasic (MerchantBasic merchantBasic);

    Task<int> AddIdentity (MerchantBasic merchantBasic, MerchantIdentity merchantIdentity);

    Task<int> AddShopIdToMerchant (MerchantBasic merchantBasic, Guid shopId);

    Task<int> CheckMerchantIdentity (string merchantAuthId, bool result);

    MerchantBasic GetMerhcntBasicByMerchantId (string merchantId);

    MerchantIdentity GetMerchantIdentityByIdentityId (string identityId);

    List<MerchantBasic> GetMerchantBasicListNotChecked(int page);

    MerchantIdentity GetMerchantIdentityByMerchantId(string merchantId);
  }
}