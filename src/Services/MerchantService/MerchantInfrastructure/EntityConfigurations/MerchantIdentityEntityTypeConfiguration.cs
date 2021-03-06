using System;
using GB_project.Services.MerchantService.MerchantDomin.Aggregateroot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GB_project.Services.MerchantService.MerchantInfrastructure.EntityConfigurations
{
  public class MerchantIdentityEntityTypeConfiguration : IEntityTypeConfiguration<MerchantIdentity>
  {
    private const string mySchema = "merchant";
    public void Configure ( EntityTypeBuilder<MerchantIdentity> builder )
    {
      builder.ToTable("MerchantIdentity", schema: mySchema);

      builder.HasKey("PkId");

      builder.Property(b => b.IdentityName).HasColumnType("nvarchar(10)");

      builder.Property(b => b.IdentityNum).HasColumnType("varchar(18)");

      builder.Property(b => b.IdentityImgF).HasColumnType("varchar(50)");

      builder.Property(b => b.IdentityImgB).HasColumnType("varchar(50)");

      builder.Property(b => b.LicenseImg).HasColumnType("varchar(50)");

      builder.Property(b => b.LicenseCode).HasColumnType("varchar(15)");

      builder.Property(b => b.LicenseName).HasColumnType("nvarchar(15)");

      builder.Property(b => b.LicenseOwner).HasColumnType("nvarchar(10)");

      builder.Property(b => b.AvailableSatartTime).HasColumnType("date");

      builder.Property(b => b.AvailableTime).HasColumnType("date");

      builder.Property(b => b.Tel).HasColumnType("varchar(11)");

      builder.Property<Guid>("MerchantId").IsRequired();
    }

  }   
}