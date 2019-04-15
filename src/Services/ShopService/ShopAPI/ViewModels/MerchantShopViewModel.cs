using System;

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

    public int Type { get; set; }

    public string Tel { get; set; }

    public string RegisterId { get; set; }

    public string Pic { get; set; }

    public bool IsIdentitied { get; set; }

    public MerchantShopViewModel(string pkId, string name, string province, string city, string district, 
                                 string location, int type, string tel, string registerId, string pic, bool isIdentitied)
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
      Pic = pic;
      IsIdentitied = isIdentitied;
    }
  }
}