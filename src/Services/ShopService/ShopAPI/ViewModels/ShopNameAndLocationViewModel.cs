namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
    public class ShopNameAndLocationViewModel
    {
      public string ShopName { get; set; }

      public string Location { get; set; }

      public ShopNameAndLocationViewModel(string shopName, string location)
      {
        ShopName = shopName;
        Location = location;
      }
    }
}
