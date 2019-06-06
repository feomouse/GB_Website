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

        Shop GetShopByMerchantIdAndShopId(string merchantId, string shopId);

        int CreateShop(Shop newShop);

        Shop GetShopByMerchantId(string merchantId);

        int IdentityMerchantOfShop(string merchantId, string shopId, bool isChecked);

        int SetGB(string shopId);
        
        int CreateShopProductType(ProductType type);

        ProductType GetProductTypeByProductTypeId(string productTypeId);

        int AddGBProduct(GBProduct newgbProduct);

        List<GBProduct> GetGBProductsByShopName(string shopName, string province, string city, string district);

        GBProduct UpdateGBProducts(GBProduct newgbProduct);

        int DeleteGBProduct(string gbProductName);

        int DeleteGBProductById(string gbProductId);

        List<ProductType> GetShopProductTypesByShopName(string shopName, string province, string city, string district);

        int DeleteProductType(string productTypePkId);

        Shop UpdateShop (string pkId, string name, string province, string city, string district, string location, string tel, string workingTime);

        string GetGBProductKeyByName (string gbProductName);

        List<GBProduct> GetGBProductsByProductId (string productTypeId);

        bool IncreGBPayAmount (string gbProductName, string shopName, int itemCost, int number);

        int GetShopsTotalCount(string province, string city, ShopType shopType);

        int SetMerchantToShop(Guid shopId, Guid merchantId);

        IList<Shop> GetShopsByMerchantId(string merchantId);

        IList<ShopImg> GetShopImgs(string shopId);

        int CreateShopImg(string shopId, string img);

        IList<GBProductImg> GetGBProductImgs(string gbProductId);

        int CreateGBProductImg(string gbProductId, string img);

        IList<Shop> GetShopsByDistrictAndType(string province, string city, string district, string shopTypeId, int page);

        IList<Shop> GetRandomShopsByCityAndType(string province, string city, string shopTypeId);

        int GetShopsNumByDistrictAndShopType(string province, string city, string district, string shopTypeId);
    
        int IncreaseVisitNum(string shopId, string year, string month);

        int IncreaseMonthSell(string shopId, string year, string month, int num);

        dynamic GetVisitNumsByYear(string shopId, string year);

        dynamic GetMonthSellsByYear(string shopId, string year);

        int DeleteShopType(string shopTypeId);
    } 
}