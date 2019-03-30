using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public interface IShopRepository : IRepository
    {
        Dictionary<int, string> GetShopTypeInfo();

        Shop GetShopByName(string shopName);

        Shop GetShopByShopId(string shopId);

        bool CheckIfIdentitied(string shopId);

        int CreateShop(Shop newShop);

        Shop GetShopByMerchantId(string merchantId);

        int IdentityMerchantOfShop(string merchantId, bool isChecked);

        int SetGB(string shopId);

        string UploadShopImg(Shop shop, string imgName, byte[] imgData);
        
        int CreateShopProductType(ProductType type);

        ProductType GetProductTypeByProductTypeId(string productTypeId);

        int AddGBProduct(GBProduct newgbProduct);

        List<GBProduct> GetGBProductsByShopName(string shopName);

        GBProduct UpdateGBProducts(GBProduct newgbProduct);
/*         List<Shop> GetShops();

        Shop GetShopByShopId(string shopId);

        List<ProductType> GetShopProductTypesByShopName(string shopName);

        ProductType GetShopProductTypeByShopProductTypeId(Guid productTypeId);

        int AddShopProduct(Product product);

        List<Product> GetShopProductsByShopName(string name); */
/*
        void AddGBRule(GBRule newgbRule);

        void AddGBProductItem(GBProductItem newGBProductItem);
*/
    } 
}