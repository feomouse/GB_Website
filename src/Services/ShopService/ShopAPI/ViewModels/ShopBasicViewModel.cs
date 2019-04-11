namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class ShopBasicViewModel
  {
    public string PkId { get; set; }
    public string Name { get ; set; }

    public string Province { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Location { get; set; }

    public string Img { get; set; }

    public ShopBasicViewModel(string pkId, string name, string province, string city, string district, string location, string img)
    {
      PkId = pkId;
      Name = name;
      Province = province;
      City = city;
      District = district;
      Location = location;
      Img = img;
    }
  }
}