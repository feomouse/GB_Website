using System;
using System.Linq;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        merchantBasic.SetIdentity(merchantIdentity);

        return _context.SaveChangesAsync();
      }

      public Task<int> AddShopIdToMerchant (MerchantBasic merchantBasic,  Guid shopId)
      {
         _context.merchantBasics.Where(m => m == merchantBasic).First().SetShopId(shopId);

         return _context.SaveChangesAsync();
      }

      public Task<int> AddIdentityIdToMerchant (MerchantBasic merchantBasic, MerchantIdentity merchantIdentity)
      {
        EntityEntry basicEntry = _context.Update(merchantBasic);

        merchantBasic.SetIdentity(merchantIdentity);

        _context.SaveChangesAsync();

        if(basicEntry.State == EntityState.Modified)
        {
          return Task.FromResult(1);
        }
        return Task.FromResult(0);
      }

      public MerchantBasic GetMerhcntBasicByMerchantId (string merchantId)
      {
        var gid = new Guid(merchantId);
        return _context.merchantBasics.Where(m => m.AuthPkId == gid).FirstOrDefault();
      }
    }
}