
using System;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class GBProductImg : Entity
  {
    public Guid MGBProductId { get; private set; }
    public GBProduct MGBProduct { get; private set; }

    public string Img { get; private set; }

    public GBProductImg()
    {
    }

    public GBProductImg(GBProduct mgbProduct, string img)
    {
      MGBProduct = mgbProduct;
      Img = img;
    }
  }
}