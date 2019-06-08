using System.Threading.Tasks;
using System;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;
using System.Collections.Generic;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public interface IMerchantRepository : IRepository
  {
    int BindShopToMerchant (string merchantId, string shopId);

    IList<MerchantShop> GetMerchantShopList (Guid merchantId); 

    Task<int> CreateMerchantBasic (MerchantBasic merchantBasic);

    Task<int> AddIdentity (MerchantIdentity merchantIdentity);

    Task<int> AddShopIdToMerchant (MerchantBasic merchantBasic, Guid shopId);

    Task<int> CheckMerchantIdentity (string merchantAuthId, string shopId, bool result);

    MerchantBasic GetMerhcntBasicByMerchantId (string merchantId);

    MerchantIdentity GetMerchantIdentityByIdentityId (string identityId);

    List<MerchantShop> GetMerchantShopListNotChecked(int page);
    int GetMerchantShopListNotCheckedNum();

    IList<MerchantIdentity> GetMerchantIdentityByMerchantId(string merchantId);

    List<MerchantBasic> GetMerchantBasics(int page);

    MerchantShop GetMerchantShop(string merchantId, string shopId);

    MerchantIdentity GetMerchantIdentityByMIdAndSId(string merchantId, string shopId);

    int GetMerchantNum();
    int UnbindShopFromMerchant(string merchantId, string shopId);
  }
}