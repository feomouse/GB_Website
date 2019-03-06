using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public interface IShopRepository : IRepository
    {
        Dictionary<int, string> GetShopTypeInfo();

        int CreateShop(Shop newShop);

        Shop GetShopByName(string shopName);

        List<Shop> GetShops();

        Shop GetShopByShopId(string shopId);

        int CreateShopProductType(ProductType type);

        List<ProductType> GetShopProductTypesByShopName(string shopName);

        ProductType GetShopProductTypeByShopProductTypeId(Guid productTypeId);

        int AddShopProduct(Product product);

        List<Product> GetShopProductsByShopName(string name);
/* 
        void AddGBProduct(GBProduct newgbProduct);

        void AddGBRule(GBRule newgbRule);

        void AddGBProductItem(GBProductItem newGBProductItem);
*/
    } 
}