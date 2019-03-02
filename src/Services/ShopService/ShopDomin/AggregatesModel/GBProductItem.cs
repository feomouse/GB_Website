using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class GBProductItem : Entity {
    public Guid PkId { get; private set; }

    public Guid GbProductId { get; private set; }

    public string GbItemName { get; private set; }

    public string GbItemImg { get; private set; }

    public int GbItemPrice { get; private set; }

    public GBProductItem () {

    }

    public GBProductItem (Guid gbProductId, string gbItemName, string gbItemImg, int gbItemPrice)
    {
      PkId = new Guid();
      GbProductId = gbProductId;
      GbItemName = gbItemName;
      GbItemImg = gbItemImg;
      GbItemPrice = gbItemPrice;
    }
  }
}