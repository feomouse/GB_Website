using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System;
using System.Collections.Generic;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class ProductType : Entity {
      public Guid PkId { get; private set; }

      public Guid ShopId { get; private set; }
      public Shop _Shop { get; private set; }

      public string TypeName { get; private set; }

      public List<Product> Products { get; private set; }

      public ProductType () {
        
      }

      public ProductType (Shop shop, string typeName)
      {
        PkId = new Guid();

        _Shop = shop;
        
        TypeName = typeName;
      }
    }
}