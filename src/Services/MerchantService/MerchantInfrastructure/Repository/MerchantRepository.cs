using System;
using System.Linq;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace GB_Project.Services.MerchantService.MerchantInfrastructure.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
      private MerchantDbContext _context;

      public MerchantRepository(MerchantDbContext context)
      {
        _context = context;
      }

      public Task<int> CreateMerchantBasic (MerchantBasic merchantBasic)
      {
        _context.merchantBasics.Add(merchantBasic);

        return _context.SaveChangesAsync();
      }

      public Task<int> AddIdentity (MerchantBasic merchantBasic, MerchantIdentity merchantIdentity)
      {
        _context.merchantIdentitys.Add(merchantIdentity);

        return _context.SaveChangesAsync();
      }

      public Task<int> AddShopIdToMerchant (MerchantBasic merchantBasic,  Guid shopId)
      {
         _context.merchantBasics.Where(m => m == merchantBasic).First().SetShopId(shopId);

         return _context.SaveChangesAsync();
      }

      public Task<int> CheckMerchantIdentity (string merchantAuthId, bool result)
      {
        var merchantBasic = _context.merchantBasics.Where(b => b.AuthPkId.ToString() == merchantAuthId).FirstOrDefault();
      
        merchantBasic.SetIsChecked(result);

        return _context.SaveChangesAsync();
      }

      public MerchantBasic GetMerhcntBasicByMerchantId (string merchantId)
      {
        var gid = new Guid(merchantId);
        return _context.merchantBasics.Where(m => m.AuthPkId == gid).FirstOrDefault();
      }

      public MerchantIdentity GetMerchantIdentityByIdentityId (string identityId)
      {
        return _context.merchantIdentitys.Where(m => m.PkId.ToString() == identityId).FirstOrDefault();
      }

      public List<MerchantBasic> GetMerchantBasicListNotChecked(int page)
      {
        return _context.merchantBasics.Where(m => m.IsChecked == false).Skip((page-1)*10).Take(10).ToList();
      }

      public MerchantIdentity GetMerchantIdentityByMerchantId(string merchantId)
      {
        return _context.merchantIdentitys.Where(m => m.MerchantId.ToString() == merchantId).FirstOrDefault();
      }

      public List<MerchantBasic> GetMerchantBasics(int page)
      {
        return _context.merchantBasics.Skip((page-1) * 10).Take(10).ToList();
      }
    }
}