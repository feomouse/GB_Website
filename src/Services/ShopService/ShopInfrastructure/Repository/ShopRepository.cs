using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using GB_Project.Services.ShopService.ShopInfrastructure.Context;

namespace GB_Project.Services.ShopService.ShopInfrastructure.Repository
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

      public Dictionary<int, string> GetShopTypeInfo()
      {
         var dic = new Dictionary<int, string>();

         dic.Add(ShopType.beauty.Id, ShopType.beauty.Name);
         dic.Add(ShopType.entertain.Id, ShopType.entertain.Name);
         dic.Add(ShopType.food.Id, ShopType.food.Name);

         return dic;
      }

      public int CreateShop(Shop newShop)
      {
        _context.shops.Add(newShop);

        return _context.SaveChanges();
      }

      public Shop GetShopByName(string shopName)
      {
        return _context.shops.Where(s => s.Name == shopName).First();
      }

      public List<Shop> GetShops()
      {
        return _context.shops.ToList();
      }

      public Shop GetShopByShopId(string shopId)
      {
        return _context.shops.Where(s => s.PkId == new Guid(shopId)).First();
      }

      public int CreateShopProductType(ProductType type)
      {
        _context.producttypes.Add(type);

        return _context.SaveChanges();
      }

      public List<ProductType> GetShopProductTypesByShopName(string shopName)
      {
        var shop = _context.shops.Where(s => s.Name == shopName).First();
        return _context.producttypes.Where(t => t.ShopId == shop.PkId).ToList();
      }

      public ProductType GetShopProductTypeByShopProductTypeId(Guid productTypeId)
      {
        return _context.producttypes.Where(pt => pt.PkId == productTypeId).First();
      }

      public int AddShopProduct(Product product)
      {
        _context.products.Add(product);

        return _context.SaveChanges();
      }

      public List<Product> GetShopProductsByShopName(string name)
      {
        List<Product> products = new List<Product>();

        Shop shop = _context.shops.Where(s => s.Name == name).First();

        List<ProductType> types = _context.producttypes.Where(p => p.ShopId == shop.PkId).ToList();

        foreach(var type in types)
        {
          products.AddRange(_context.products.Where(p => p._ProductType == type).ToList());
        }

        return products;
      }
    }
}