using System;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
    public interface IQuery
    {
      Shop getShopByName( string name );  

      ShopMerchant getShopMerchantByKey( Guid merchantId, Guid shopId );

      Product getProductByName(string name);

      GBProduct getGBProductByName( string name );

      GBProductItem getGBProductItemByGbIdAndName( Guid gbid, string name);

      ProductType getProductTypeByNameAndShopId(string name, Guid shopId);

      GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId);
    } 
}