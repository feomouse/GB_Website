using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class GBProduct : Entity {
    public Guid PkId { get; private set; }

    public Guid ShopId { get; private set; }

    public string ProductName { get; private set; }

    public int OrinPrice { get; private set; }

    public int Price { get; private set; }

    public string Quantity { get; private set; }

    public DateTime VailSDate { get; private set; }

    public DateTime VailEDate { get; private set; }

    public string VailTime { get; private set; }

    public string Img { get; private set; }

    public string Remark { get; private set; }

    public List<GBRule> GbRule { get; set; }

    public List<GBProductItem> Items { get; set; }

    public GBProduct () {

    }

    public GBProduct (Guid shopId, string productName, int orinPrice, int price, string quantity, DateTime vailSDate, DateTime vailEDate, string vailTime, string img, string remark)
    {
      PkId = new Guid();
      ShopId = shopId;
      ProductName = productName;
      OrinPrice = orinPrice;
      Price = price;
      Quantity = quantity;
      VailSDate = vailSDate;
      VailEDate = vailEDate;
      VailTime = vailTime;
      Img = img;
      Remark = remark;
    }

    public void CreateGBProduct (GBProduct gbProduct) {
    }
  }
}