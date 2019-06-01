using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GB_Project.Services.MerchantService.MerchantInfrastructure.EntityConfigurations
{
    public class MerchantShopEntityTypeConfiguration : IEntityTypeConfiguration<MerchantShop>
    {
      public void Configure( EntityTypeBuilder<MerchantShop> builder )
      {
        builder.ToTable("MerchantShops", schema: "merchant");

        builder.HasKey(c =>  new {c.MBasicId, c.ShopId});

        //builder.Property(c => c.MIdentity).IsRequired(false);
        
        builder.Property(b => b.IsChecked).HasColumnType("bit");
      }
    }
}