using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public interface IShopRepository : IRepository
    {
        Dictionary<int, string> GetShopTypeInfo();

        Guid CreateShop(Shop newShop);

        Shop GetShopByName(string shopName);

        Guid CreateShopProductType(ProductType type);

        List<ProductType> GetShopProductTypesByShopId(Guid shopId);

        Guid AddShopProduct(Product product);
/* 
        void AddGBProduct(GBProduct newgbProduct);

        void AddGBRule(GBRule newgbRule);

        void AddGBProductItem(GBProductItem newGBProductItem);
*/
    } 
}