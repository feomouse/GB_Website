using GB_project.Services.ShopService.ShopDomin.SeedWork;
using System;

namespace GB_project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class Product : Entity
    {
      public Guid PkId { get; private set; }

      public Guid ShopId { get; private set; }

      public string ProductName { get; private set; }

      public Guid ProductType { get; private set; }

      public string ProductImg { get; private set; }

      public int ProductPrice { get; private set; }

      public int MSellNum { get; private set; }

      public int PraiseNum { get; private set; }

      public bool IsDisplay { get; private set; }

      public Product () {

      }

      public Product ( Guid shopId, string productName, Guid productType, string productImg, int productPrice, int mSellNum, int praiseNum, bool isDisplay) 
      {
        PkId = new Guid();
        ShopId = shopId;
        ProductName = productName;
        ProductType = productType;
        ProductImg = productImg;
        ProductPrice = productPrice;
        MSellNum = mSellNum;
        PraiseNum = praiseNum;
        IsDisplay = isDisplay;
      }

      public void CreateProduct ( Product product )
      {
      }
    } 
}