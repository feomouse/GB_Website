using System;
using GB_Project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel
{
  public class MerchantIdentity : Entity
  {
    public Guid PkId { get; private set; }
     
    public string IdentityName { get; private set; }

    public string IdentityNum { get; private set; }

    public string IdentityImgF { get; private set; }

    public string IdentityImgB { get; private set; }

    public string LicenseImg { get; private set; }

    public string LicenseCode { get; private set; }

    public string LicenseName { get; private set; }

    public string LicenseOwner { get; private set; }

    public DateTime AvailableSatartTime { get; private set; }

    public DateTime AvailableTime { get; private set; }

    public string Tel { get; private set; }

    public Guid MerchantId { get; private set; }
    public MerchantBasic Merchant { get; private set; }

    public MerchantIdentity ()
    {

    }

    public MerchantIdentity ( string identityName, string identityNum, string identityImgF, string identityImgB, string licenseImg, 
                          string licenseCode, string licenseName, string licenseOwner, DateTime availableSatartTime, 
                          DateTime availableTime, string tel, Guid merchantId, MerchantBasic merchant)
    {
      PkId = Guid.NewGuid();
      IdentityName = identityName;
      IdentityNum = identityNum;
      IdentityImgF = identityImgF;
      IdentityImgB = identityImgB;
      LicenseImg = licenseImg;
      LicenseCode = licenseCode;
      LicenseName = licenseName;
      LicenseOwner = licenseOwner;
      AvailableSatartTime = availableSatartTime;
      AvailableTime = availableTime;
      Tel = tel;
      MerchantId = merchantId;
      Merchant = merchant;
    }

    public void SetMerchantBasic(MerchantBasic basic)
    {
      Merchant = basic;
    }
  }   
}