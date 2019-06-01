using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class GBProduct : Entity {
    public Guid PkId { get; private set; }

    public string ProductName { get; private set; }

    public double OrinPrice { get; private set; }

    public double Price { get; private set; }

    public string Quantity { get; private set; }

    public DateTime VailSDate { get; private set; }

    public DateTime VailEDate { get; private set; }

    public string VailTime { get; private set; }

    public string Img { get; private set; }

    public string Remark { get; private set; }

    public bool IsDisplay { get; private set; }

    public int PraiseNum { get; private set; }

    public int MSellNum { get; private set; }

    public Guid ProductTypeId { get; private set; }

    public ProductType ProductType { get; private set; } 

    public List<GBProductImg> Imgs { get; private set; }

    public GBProduct () {

    }

    public GBProduct (string productName, double orinPrice, double price, string quantity, DateTime vailSDate, DateTime vailEDate, string vailTime, string img, string remark, ProductType productType)
    {
      PkId = new Guid();
      ProductName = productName;
      OrinPrice = orinPrice;
      Price = price;
      Quantity = quantity;
      VailSDate = vailSDate;
      VailEDate = vailEDate;
      VailTime = vailTime;
      Img = img;
      Remark = remark;
      IsDisplay = true;
      PraiseNum = 0;
      MSellNum = 0;
      ProductType = productType;
    }

    public GBProduct (Guid pkId, string productName, double orinPrice, double price, string quantity, DateTime vailSDate, DateTime vailEDate, string vailTime, string img, string remark, ProductType productType)
    {
      PkId = pkId;
      ProductName = productName;
      OrinPrice = orinPrice;
      Price = price;
      Quantity = quantity;
      VailSDate = vailSDate;
      VailEDate = vailEDate;
      VailTime = vailTime;
      Img = img;
      Remark = remark;
      IsDisplay = true;
      PraiseNum = 0;
      MSellNum = 0;
      ProductType = productType;
    }

    public void CreateGBProduct (GBProduct gbProduct) {
    }

    public void SetProductName(string productName)
    {
      ProductName = productName;
    }

    public void SetOrinPrice(double orinPrice)
    {
      OrinPrice = orinPrice;
    }

    public void SetPrice(double price)
    {
      Price = price;
    }

    public void SetQuantity(string quantity)
    {
      Quantity = quantity;
    }

    public void SetVailSDate(DateTime time)
    {
      VailSDate = time;
    }

    public void SetVailEDate(DateTime time)
    {
      VailEDate = time;
    }

    public void SetVailTime(string time)
    {
      VailTime = time;
    }

    public void SetImg(string img)
    {
      Img = img;
    }

    public void SetRemark(string remark)
    {
      Remark = remark;
    }

    public void SetIsDisplay(bool isDisplay)
    {
      IsDisplay = isDisplay;
    }

    public void SetProductType(ProductType type)
    {
      ProductType = type;
    }

    public void IncreMSellNum(int num)
    {
      MSellNum += num;
    }
  }
}