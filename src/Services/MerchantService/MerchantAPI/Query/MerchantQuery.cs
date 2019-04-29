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

    public List<MerchantBasic> GetMerchantBasicListNotChecked(int page)
    {
      return _repo.GetMerchantBasicListNotChecked(page);
    }

    public MerchantIdentity GetMerchantIdentityByMerchantId(string merchantId)
    {
      return _repo.GetMerchantIdentityByMerchantId(merchantId);
    }
  }
}