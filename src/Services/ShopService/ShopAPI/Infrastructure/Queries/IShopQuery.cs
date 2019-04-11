using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
    public interface IShopQuery
    {
      //List<Shop> getShops();
      Shop getShopByName( string name );  

      Shop getShopByMerchantId( string merchantId);

      List<GBProduct> getGBProductsByShopName( string shopName);

      List<Shop> getShopListByShopType(int shopType);

      string getGBProductByName(string name);

      //Product getProductByName(string name);

      //List<Product> GetShopProductsByShopName(string shopName);

      //GBProduct getGBProductByName( string name );

      //GBProductItem getGBProductItemByGbIdAndName( Guid gbid, string name);

      List<ProductType> getShopProductTypesByShopName(string shopName);

      //GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId);
    } 
}