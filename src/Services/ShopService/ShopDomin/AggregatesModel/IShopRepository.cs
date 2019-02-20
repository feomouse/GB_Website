using System;
using System.Threading.Tasks;
using GB_project.Services.ShopService.ShopDomin.SeedWork;

namespace GB_project.Services.ShopService.ShopDomin.AggregatesModel
{
    public interface IShopRepository : IRepository
    {
        void CreateShop(Shop newShop);

        void AddProduct(Product newProduct);

        void AddMerchant(ShopMerchant newMerchant);

        void AddGBProduct(GBProduct newgbProduct);

        void AddGBRule(GBRule newgbRule);

        void AddGBProductItem(GBProductItem newGBProductItem);

        void AddProductType(ProductType newproductType);

        ProductType GetProductTypeById(Guid pkid);

        Task<int> Save();
    }
}