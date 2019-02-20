using GB_project.Services.ShopService.ShopDomin.SeedWork;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GB_project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class ShopType : Enumeration
    {
      public static ShopType beauty = new ShopType(1, "丽人");

      public static ShopType food = new ShopType(2, "饮食");

      public static ShopType entertain = new ShopType(3, "娱乐");

      public ShopType ()
      {

      }

      public ShopType (int id, string name) : base ( id, name)
      {
        
      }

      public static IEnumerable<ShopType> List() => new[] { beauty, food, entertain};

      public static ShopType FromName (string name)
      {
        var state = List().SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
        
        return state;
      }

      public static ShopType FromId (int id)
      {
        var state = List().SingleOrDefault(s => s.Id == id);

        return state;
      }
    }
}