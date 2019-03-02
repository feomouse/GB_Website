using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class Product : Entity
    {
      public Guid PkId { get; private set; }

      public string ProductName { get; private set; }

      public Guid ProductTypeId { get; private set; }

      public ProductType _ProductType { get; private set; }

      public string ProductImg { get; private set; }

      public int ProductPrice { get; private set; }

      public int MSellNum { get; private set; }

      public int PraiseNum { get; private set; }

      public bool IsDisplay { get; private set; }

      public Product () {

      }

      public Product ( string productName, ProductType productType, string productImg, int productPrice, int mSellNum, int praiseNum, bool isDisplay) 
      {
        PkId = new Guid();
        ProductName = productName;
        _ProductType = productType;
        ProductImg = productImg;
        ProductPrice = productPrice;
        MSellNum = mSellNum;
        PraiseNum = praiseNum;
        IsDisplay = isDisplay;
      }
    } 
}