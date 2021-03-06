using System;
using GB_project.Services.MerchantService.MerchantDomin.SeedWork;

namespace GB_project.Services.MerchantService.MerchantDomin.Aggregateroot
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

    public MerchantIdentity ()
    {

    }

    public MerchantIdentity ( string identityName, string identityNum, string identityImgF, string identityImgB, string licenseImg, 
                          string licenseCode, string licenseName, string licenseOwner, DateTime availableSatartTime, 
                          DateTime availableTime, string tel)
    {
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
    }
  }   
}