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

      public int BindShopToMerchant (string merchantId, string shopId)
      {
        var mBasic = _context.merchantBasics.Where(m => m.AuthPkId.ToString() == merchantId).FirstOrDefault();
        if(mBasic.Shops == null)  mBasic.SetShops();
        mBasic.Shops.Add(new MerchantShop(mBasic, new Guid(shopId)));

        return _context.SaveChanges();
      }

      public IList<MerchantShop> GetMerchantShopList (Guid merchantId)
      {
        return _context.merchantShops.Where(s => s.MBasicId.ToString() == merchantId.ToString()).ToList();
      }

      public Task<int> CreateMerchantBasic (MerchantBasic merchantBasic)
      {
        _context.merchantBasics.Add(merchantBasic);

        return _context.SaveChangesAsync();
      }

      public Task<int> AddIdentity (MerchantIdentity merchantIdentity)
      {
        _context.merchantIdentitys.Add(merchantIdentity);

        return _context.SaveChangesAsync();
      }

      public Task<int> AddShopIdToMerchant (MerchantBasic merchantBasic,  Guid shopId)
      {
         _context.merchantShops.Add(new MerchantShop(merchantBasic.AuthPkId, shopId));

         return _context.SaveChangesAsync();
      }

      public Task<int> CheckMerchantIdentity (string merchantAuthId, string shopId, bool result)
      {
        var merchantShop = _context.merchantShops.Where(b => (b.MBasicId.ToString() == merchantAuthId && b.ShopId.ToString() == shopId)).FirstOrDefault();
      
        merchantShop.SetIsChecked(result);

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

      public List<MerchantShop> GetMerchantShopListNotChecked(int page)
      {
        return _context.merchantShops.Where(m => m.IsChecked == false).Skip((page-1)*10).Take(10).ToList();
      }

      public IList<MerchantIdentity> GetMerchantIdentityByMerchantId(string merchantId)
      {
        return _context.merchantShops.Where(m => m.MBasicId.ToString() == merchantId).Select(i => i.MIdentity).ToList();
      }

      public List<MerchantBasic> GetMerchantBasics(int page)
      {
        return _context.merchantBasics.Skip((page-1) * 10).Take(10).ToList();
      }

      public MerchantShop GetMerchantShop(string merchantId, string shopId)
      {
        return _context.merchantShops.Where(ms => (ms.MBasicId.ToString() == merchantId && ms.ShopId.ToString() == shopId)).FirstOrDefault();
      }

      public MerchantIdentity GetMerchantIdentityByMIdAndSId(string merchantId, string shopId)
      {
        var ms = GetMerchantShop(merchantId, shopId);
        if(ms == null) return default(MerchantIdentity);

        else return ms.MIdentity;
      }
    }
}