using System;
using System.Linq;
using System.Threading.Tasks;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_project.Services.ShopService.ShopDomin.SeedWork;
using GB_project.Services.ShopService.ShopInfrastructure.Context;

namespace GB_project.Services.ShopService.ShopInfrastructure.Repository
{
    public class ShopRepository : IShopRepository
    {
      private readonly  ShopDbContext _context;
      public ShopRepository ( ShopDbContext context )
      {
        _context = context;
      }

      public ShopDbContext UnitOfWork
      {
        get 
        {
          return _context;
        }
      }

      public void CreateShop(Shop newShop)
      {
        _context.shop.Add(newShop);
      }

      public void AddProduct(Product newProduct)
      {
        _context.product.Add(newProduct);
      }

      public void AddMerchant(ShopMerchant newMerchant)
      {
        _context.shopmerchant.Add(newMerchant);
      }

      public void AddGBProduct(GBProduct newgbProduct)
      {
        _context.gbproduct.Add(newgbProduct);
      }

      public void AddGBRule(GBRule newgbRule)
      {
        _context.gbrule.Add(newgbRule);
      }

      public void AddGBProductItem(GBProductItem newGBProductItem)
      {
        _context.gbitems.Add(newGBProductItem);
      }

      public void AddProductType(ProductType newproductType)
      {
        _context.producttype.Add(newproductType);
      }

      public ProductType GetProductTypeById(Guid pkid)
      {
        return _context.producttype.Single(i => i.PkId == pkid);
      }

      public async Task<int> Save()
      {
       return await _context.SaveChangesAsync();
      }
    }
}