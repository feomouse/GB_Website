namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class SearchShopViewModel
  {
    public string PkId { get; set; }

    public string Name { get; set; }

    public string Province { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Location { get; set; }

    public string Pic { get; set;}

    public string Tel { get; set; }

    public int Type { get; set; }

    public string RegisterId { get; set; }

    public SearchShopViewModel(string pkId, string name, string province, string city, string district, string location,
                          string pic, string tel, int type, string registerId)
    {
      PkId = pkId;
      Name = name;
      Province = province;
      City = city;
      District = district;
      Location = location;
      Pic = pic;
      Tel = tel;
      Type = type;
      RegisterId = registerId;
    }
  }
}