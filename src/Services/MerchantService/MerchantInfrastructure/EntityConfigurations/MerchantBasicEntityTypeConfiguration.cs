using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GB_Project.Services.MerchantService.MerchantInfrastructure.EntityConfigurations
{
    public class MerchantBasicEntityTypeConfiguration : IEntityTypeConfiguration<MerchantBasic>
    {
      private const string mySchema = "merchant";
      public void Configure( EntityTypeBuilder<MerchantBasic> builder )
      {
        builder.ToTable("MerchantBasic", schema: mySchema);

        builder.HasKey(c => c.AuthPkId);
      }
    }
}