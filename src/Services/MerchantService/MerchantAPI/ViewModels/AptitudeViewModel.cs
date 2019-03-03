using System;

namespace GB_Project.Services.MerchantService.MerchantAPI.ViewModels
{
  public class AptitudeViewModel
  {
    public string MerchantId { get; set; }
    public string IdentityName { get; set; }

    public string IdentityNum { get; set; }

    public string IdentityImgF { get; set; }

    public string IdentityImgB { get; set; }

    public string LicenseImg { get; set; }

    public string LicenseCode { get; set; }

    public string LicenseName { get; set; }

    public string LicenseOwner { get; set; }

    public DateTime AvailableStartTime { get; set; }

    public DateTime AvailableTime { get; set; }

    public string Tel { get; set; }

    public AptitudeViewModel(string merchantId, string identityName, string identityNum, string identityImgF,
                             string identityImgB, string licenseImg, string licenseCode, string licenseName,
                             string licenseOwner, DateTime availableStartTime, DateTime availableTime, string tel)
    { 
      MerchantId = merchantId;
      IdentityName = identityName;
      IdentityNum = identityNum;
      IdentityImgF =identityImgF;
      IdentityImgB = identityImgB;
      LicenseImg = licenseImg;
      LicenseCode = licenseCode;
      LicenseOwner = licenseName;
      LicenseOwner = licenseOwner;
      AvailableStartTime = availableStartTime;
      AvailableTime = availableTime;
      Tel = tel;
    }
  }
}