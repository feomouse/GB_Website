namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class ProductTypesViewModel
  {
    public string PkId { get; set; }

    public string ShopId { get; set; }

    public string TypeName { get; set; }

    public ProductTypesViewModel (string pkId, string shopId, string typeName)
    {
      PkId = pkId;
      ShopId = shopId;
      TypeName = typeName;
    }
  }
}