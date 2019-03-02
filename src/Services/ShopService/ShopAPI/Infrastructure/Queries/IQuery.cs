using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
    public interface IQuery
    {
      Shop getShopByName( string name );  

      Product getProductByName(string name);

      GBProduct getGBProductByName( string name );

      GBProductItem getGBProductItemByGbIdAndName( Guid gbid, string name);

      ProductType getProductTypeByNameAndShopId(string name, Guid shopId);

      GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId);
    } 
}