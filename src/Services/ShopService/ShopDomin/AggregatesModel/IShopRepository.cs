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

        List<Shop> GetShopListByShopType(int shopType);

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

        int DeleteGBProduct(string gbProductName);

        List<ProductType> GetShopProductTypesByShopName(string shopName);

        int DeleteProductType(string productTypePkId);

        Shop UpdateShop (Shop shop);

        string GetGBProductKeyByName (string gbProductName);
    } 
}