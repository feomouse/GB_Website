using System.Threading.Tasks;
using System;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public interface IMerchantRepository : IRepository
  {
    Task<int> CreateMerchantBasic (MerchantBasic merchantBasic);

    Task<int> AddIdentity (MerchantBasic merchantBasic, MerchantIdentity merchantIdentity);

    Task<int> AddShopIdToMerchant (MerchantBasic merchantBasic, Guid shopId);

    Task<int> AddIdentityIdToMerchant (MerchantBasic merchantBasic, MerchantIdentity merchantIdentity);

    MerchantBasic GetMerhcntBasicByMerchantId (string merchantId);
  }
}