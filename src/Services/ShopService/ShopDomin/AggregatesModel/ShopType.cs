using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class ShopType : Enumeration
    {
      public static ShopType beauty = new ShopType(1, "丽人", "http://localhost:50020/20360fa7782b962dc152db83f9293193.jpg");

      public static ShopType food = new ShopType(2, "饮食", "http://localhost:50020/9fc952c6fdb75d8719c53370983a66d6.jpg");

      public static ShopType entertain = new ShopType(3, "娱乐", "http://localhost:50020/d930c84fc2ac4e9ce9c5823af69afc0e.jpg");

      public string Img { get; set; }

      public ShopType ()
      {

      }

      public ShopType (int id, string name, string img) : base ( id, name)
      {
        Img = img;
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