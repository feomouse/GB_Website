using System.Threading.Tasks;
using GB_project.Services.MerchantService.MerchantDomin.Aggregateroot;
using GB_project.Services.MerchantService.MerchantInfrastructure.Context;

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

      public int AddIdentity ( MerchantIdentity merchantIdentity )
      {
        return 0;
      }
    }
}