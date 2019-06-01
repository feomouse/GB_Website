
using System;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class GBProductImg : Entity
  {
    public Guid GBProductPkId { get; private set;}

    public string Img { get; private set; }

    public GBProductImg(string img)
    {
      Img = img;
    }
  }
}