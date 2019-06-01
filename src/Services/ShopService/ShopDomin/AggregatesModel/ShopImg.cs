
using System;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class ShopImg : Entity
  {
    public Guid ShopPkId { get; private set; }

    public string Img { get; private set; }

    public ShopImg(string img)
    {
      Img = img;
    }
  }
}