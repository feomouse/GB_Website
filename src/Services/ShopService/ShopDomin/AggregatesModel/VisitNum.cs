using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class VisitNum : Entity
    {
      public Guid MShopId { get; private set; }
      public Shop MShop { get; private set; }

      public string Year { get; private set; }

      public string Month { get; private set; }

      public int Num { get; private set; }

      public VisitNum ()
      {
      }

      public VisitNum (Shop mShop, string year, string month, int num)
      {
        MShop = mShop;
        Year = year;
        Month = month;
        Num = num;
      }

      public void IncreaseNum()
      {
        this.Num++;
      }
    }
}