using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class ShopType : Entity
    {
      public Guid PkId { get; private set; }

      public string Name { get; private set; }

      public string Img { get; private set; }

      public List<Shop> Shops { get; private set;}

      public ShopType ()
      {

      }

      public ShopType (string name, string img)
      {
        PkId = Guid.NewGuid();
        Name = name;
        Img = img;
      }

      public ShopType (Guid pkId, string name, string img)
      {
        PkId = pkId;
        Name = name;
        Img = img;
      }

      public void SetName(string name)
      {
        Name = name;
      }

      public void SetImg(string img)
      {
        Img = img;
      }
    }
}