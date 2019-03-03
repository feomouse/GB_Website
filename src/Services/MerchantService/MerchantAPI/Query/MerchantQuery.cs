using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

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

    public MerchantBasic GetMerchantBasicByMerchantId(Guid merchantId)
    {
/*        using(var connection = new SqlConnection(connectionString))
       {
         connection.Open();

         return connection.Query<MerchantBasic>(@"SELECT * FROM [merchant].[MerchantBasic] WHERE AuthPkId = @MerId",
                                         new {MerId = merchantId}).First();
       } */
       return _repo.GetMerhcntBasicByMerchantId(merchantId);
    }
  }
}