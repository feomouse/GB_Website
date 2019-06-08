using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace GB_Project.Services.MerchantService.MerchantAPI.Query
{
  public class MerchantQuery : IMerchantQuery
  {
    private string connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Merchant;User=sa;Password=107409;";
 
    private IMerchantRepository _repo;
    public MerchantQuery(IMerchantRepository repo)
    {
      _repo = repo;
    }

    public MerchantBasic GetMerchantBasicByMerchantId(string merchantId)
    {

       return _repo.GetMerhcntBasicByMerchantId(merchantId);
    }

    public MerchantIdentity GetMerchantIdentityByIdentityId(string identityId)
    {
      return _repo.GetMerchantIdentityByIdentityId(identityId);
    }

    public List<MerchantShop> GetMerchantShopListNotChecked(int page)
    {
      return _repo.GetMerchantShopListNotChecked(page);
    }

    public int GetMerchantShopListNotCheckedNum()
    {
      return _repo.GetMerchantShopListNotCheckedNum();
    }

    public IList<MerchantIdentity> GetMerchantIdentityByMerchantId(string merchantId)
    {
      return _repo.GetMerchantIdentityByMerchantId(merchantId);
    }

    public List<MerchantBasic> GetMerchantBasics(int page)
    {
      return _repo.GetMerchantBasics(page);
    }

    public IList<MerchantShop> GetMerchantShops(string merchantId)
    {
      return _repo.GetMerchantShopList(new Guid(merchantId));
    }

    public MerchantShop GetMerchantShop(string merchantId, string shopId)
    {
      return _repo.GetMerchantShop(merchantId, shopId);
    }

    public MerchantIdentity GetMerchantIdentityByMIdAndSId(string merchantId, string shopId)
    {
      return _repo.GetMerchantIdentityByMIdAndSId(merchantId, shopId);
    }

    public int GetMerchantNum()
    {
      return _repo.GetMerchantNum();
    }
  }
}