using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class RandomShopViewModel
  {
    public string PkId { get; set; }

    public string Name { get; set; }

    public string Province { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Location { get; set; }

    public string ShopTypePkId { get; private set; }

    public string Tel { get; set; }

    public string RegisterId { get; set; }

    public string Img { get; set; }

    public string WorkingTime { get; set; }

    public RandomShopViewModel(string pkId, string name, string province, string city, string district, string location,
                          string tel, string shopTypePkId, string registerId, string img, string workingTime)
    {
      PkId = pkId;
      Name = name;
      Province = province;
      City = city;
      District = district;
      Location = location;
      Tel = tel;
      ShopTypePkId = shopTypePkId;
      RegisterId = registerId;
      Img = img;
      WorkingTime = workingTime;
    }
  }
}