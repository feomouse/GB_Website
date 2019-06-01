using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class MerchantShopViewModel
  {
    public string PkId { get; set; }

    public string Name { get; set; }

    public string Province { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Location { get; set; }

    public ShopType Type { get; set; }

    public string Tel { get; set; }

    public string RegisterId { get; set; }

    public bool IsIdentitied { get; set; }

    public MerchantShopViewModel(string pkId, string name, string province, string city, string district, 
                                 string location, ShopType type, string tel, string registerId, bool isIdentitied)
    {
      PkId = pkId;
      Name = name;
      Province = province;
      City = city;
      District = district;
      Location = location;
      Type = type;
      Tel = tel;
      RegisterId = registerId;
      IsIdentitied = isIdentitied;
    }
  }
}