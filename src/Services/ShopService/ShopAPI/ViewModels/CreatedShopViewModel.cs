namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class CreatedShopViewModel
  {
    public string PkId { get; set; }

    public string RegisterId { get; set; }

    public CreatedShopViewModel(string pkId, string registerId)
    {
      PkId = pkId;
      RegisterId = registerId;
    }
  }
}