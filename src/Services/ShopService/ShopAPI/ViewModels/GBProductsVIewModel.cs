using System;

namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class GBProductsVIewModel
  {
    public Guid PkId { get; private set; }

    public string ProductName { get; private set; }

    public double OrinPrice { get; private set; }

    public double Price { get; private set; }

    public string Quantity { get; private set; }

    public DateTime VailSDate { get; private set; }

    public DateTime VailEDate { get; private set; }

    public string VailTime { get; private set; }

    public string Remark { get; private set; }

    public bool IsDisplay { get; private set; }

    public int PraiseNum { get; private set; }

    public int MSellNum { get; private set; }

    public Guid ProductTypeId { get; private set; }

    public GBProductsVIewModel(Guid pkId, string productName, double orinPrice, double price, string quantity, DateTime vailSDate, DateTime vailEDate
                              , string vailTime, string remark, bool isDisplay, int praiseNum, int mSellNum, Guid productTypeId)
    {
      PkId = pkId;
      ProductName = productName;
      OrinPrice = orinPrice;
      Price = price;
      Quantity = quantity;
      VailSDate = vailSDate;
      VailEDate = vailEDate;
      VailTime = vailTime;
      Remark = remark;
      IsDisplay = isDisplay;
      PraiseNum = praiseNum;
      MSellNum = mSellNum;
      ProductTypeId = productTypeId;
    }
  }
}