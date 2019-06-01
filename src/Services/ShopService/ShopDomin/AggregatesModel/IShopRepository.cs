using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
    public interface IShopRepository : IRepository
    {
        IList<ShopType> GetShopTypeInfo();
/*
        bool CreateShopType();

        bool CreateShopImg();

        IList<ShopImg> GetShopImgs();

        bool CreateGBProductImg();

        IList<GBProductImg> GetGBProductImg();
 */

        int CreateShopType(ShopType shopType);

        ShopType EditShopType(ShopType newShopType);

        ShopType GetShopTypeByPkId(string pkId);

        int AddShopToShopType(string shopTypeId, Shop shop);

        IList<Shop> GetShopsByNameAndCity(string shopName, string province, string city);
      
        IList<Shop> GetShopsByMerchantIds(IList<string> merchantIds);

        Shop GetShopByName(string shopName);

        Shop GetShopByNameAndCity(string shopName, string province, string city);

        Shop GetShopByShopId(string shopId);

        List<Shop> GetShopListByShopTypeAndCity(string province, string city, ShopType shopType, int page);

        List<Shop> GetShopListByCity(string province, string city);

        bool CheckIfIdentitied(string shopId);

        int CreateShop(Shop newShop);

        Shop GetShopByMerchantId(string merchantId);

        int IdentityMerchantOfShop(string merchantId, bool isChecked);

        int SetGB(string shopId);
        
        int CreateShopProductType(ProductType type);

        ProductType GetProductTypeByProductTypeId(string productTypeId);

        int AddGBProduct(GBProduct newgbProduct);

        List<GBProduct> GetGBProductsByShopName(string shopName, string province, string city);

        GBProduct UpdateGBProducts(GBProduct newgbProduct);

        int DeleteGBProduct(string gbProductName);

        List<ProductType> GetShopProductTypesByShopName(string shopName, string province, string city);

        int DeleteProductType(string productTypePkId);

        Shop UpdateShop (Shop shop);

        string GetGBProductKeyByName (string gbProductName);

        List<GBProduct> GetGBProductsByProductId (string productTypeId);

        bool IncreGBPayAmount (string gbProductName, string shopName, int itemCost, int number);

        int GetShopsTotalCount(string province, string city, ShopType shopType);

        int SetMerchantToShop(Guid shopId, Guid merchantId);

        IList<Shop> GetShopsByMerchantId(string merchantId);
    } 
}