namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class CreatedShopViewModel
  {
    public string PkId { get; set; }

    public CreatedShopViewModel(string pkId)
    {
      PkId = pkId;
    }
  }
}