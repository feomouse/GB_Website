
using System;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class ShopImg : Entity
  {
    public Guid MShopId { get; private set; }
    public Shop MShop { get; private set; }

    public string Img { get; private set; }

    public ShopImg()
    {

    }

    public ShopImg(Shop mShop, string img)
    {
      MShop = mShop;
      Img = img;
    }
  }
}