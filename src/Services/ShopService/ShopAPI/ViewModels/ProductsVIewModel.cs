using System;

namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class ProductsViewModel
  {
      public Guid PkId { get; private set; }

      public string ProductName { get; private set; }

      public Guid ProductTypeId { get; private set; }

      public string ProductImg { get; private set; }

      public int ProductPrice { get; private set; }

      public int MSellNum { get; private set; }

      public int PraiseNum { get; private set; }

      public bool IsDisplay { get; private set; }

      public ProductsViewModel(Guid pkId, string productName, Guid productTypeId, string productImg, 
                               int productPrice, int mSellNum, int praiseNum, bool isDisplay)
      {
        PkId = pkId;
        ProductName = productName;
        ProductTypeId = productTypeId;
        ProductImg = productImg;
        ProductPrice = productPrice;
        MSellNum = mSellNum;
        PraiseNum = praiseNum;
        IsDisplay = isDisplay;
      }
  }
}