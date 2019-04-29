namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class GetShopListByShopIdListCommand
  {
    public string ShopId {get; set; }

    public GetShopListByShopIdListCommand(string shopId)
    {
      ShopId = shopId;
    }
  }
}