using System;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
    public interface IShopQuery
    {
      //List<Shop> getShops();
      Shop getShopByName( string name );

      IList<Shop> getShopsByMerchantIds(IList<string> merchantIds);

      Shop getShopByNameAndCity(string name, string province, string city);

      ShopType getShopTypeByPkId(string pkId);

      IList<Shop> getShopsByMerchantId(string merchantId);

      Shop getShopByMerchantId( string merchantId);

      Shop getShopByShopId(string shopId);

      List<GBProduct> getGBProductsByShopName( string shopName, string province, string city, string district);

      List<Shop> getShopListByShopTypeAndCity(string province, string city, ShopType shopType, int page);

      string getGBProductByName(string name);

      List<GBProduct> getGBProductByProductTypeId(string productTypeId);

      List<Shop> getShopListByCity(string province, string city);

      //Product getProductByName(string name);

      //List<Product> GetShopProductsByShopName(string shopName);

      //GBProduct getGBProductByName( string name );

      //GBProductItem getGBProductItemByGbIdAndName( Guid gbid, string name);

      List<ProductType> getShopProductTypesByShopName(string shopName, string province, string city, string district);

      //GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId);

      int getShopsTotalCount(string province, string city, ShopType shopType);

      IList<Shop> getShopsByNameAndCity(string shopName, string province, string city);

      IList<ShopType> getShopTypes();

      IList<ShopImg> getShopImgs(string shopId);

      IList<GBProductImg> getGBProductImgs(string gbProductId);

      IList<Shop> getShopsByDistrictAndType(string province, string city, string district, string shopTypeId, int page);

      IList<Shop> getRandomShopsByCityAndType(string province, string city, string shopTypeId);

      int getShopsNumByDistrictAndShopType(string province, string city, string district, string shopTypeId);
    } 
}