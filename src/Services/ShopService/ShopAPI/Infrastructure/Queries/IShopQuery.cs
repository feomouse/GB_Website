using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
    public interface IShopQuery
    {
      List<Shop> getShops();
      Shop getShopByName( string name );  

      Product getProductByName(string name);

      List<Product> GetShopProductsByShopName(string shopName);

      GBProduct getGBProductByName( string name );

      GBProductItem getGBProductItemByGbIdAndName( Guid gbid, string name);

      List<ProductType> getShopProductTypesByShopName(string shopName);

      GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId);
    } 
}