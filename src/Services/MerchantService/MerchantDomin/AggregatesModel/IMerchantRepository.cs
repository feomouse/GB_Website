using System.Threading.Tasks;
using GB_project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_project.Services.MerchantService.MerchantDomin.Aggregateroot
{
  public interface IMerchantRepository : IRepository
  {
    Task<int> CreateMerchantBasic (MerchantBasic merchantBasic);

    int AddIdentity ( MerchantIdentity merchantIdentity );
  }
}