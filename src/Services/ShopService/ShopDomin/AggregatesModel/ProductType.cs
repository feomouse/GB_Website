using GB_project.Services.ShopService.ShopDomin.SeedWork;
using System;

namespace GB_project.Services.ShopService.ShopDomin.AggregatesModel
{
    public class ProductType : Entity {
      public Guid PkId { get; private set; }

      public Guid ShopId { get; private set; }

      public string TypeName { get; private set; }

      public ProductType () {
        
      }

      public ProductType (Guid shopId, string typeName)
      {
        PkId = new Guid();

        ShopId = shopId;
        
        TypeName = typeName;
      }

      public void AddProductType(ProductType productType)
      {
      }
    }
}