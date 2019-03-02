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

      public Guid CreateShop(Shop newShop)
      {
        _context.shops.Add(newShop);

        _context.SaveChanges();

        return _context.shops.Where(s => s.Name == newShop.Name).Single().PkId;
      }

      public Shop GetShopByName(string shopName)
      {
        return _context.shops.Where(s => s.Name == shopName).SingleOrDefault();
      }

      public Guid CreateShopProductType(ProductType type)
      {
        _context.producttypes.Add(type);

        _context.SaveChanges();

        return _context.producttypes.Where(t => t.TypeName == type.TypeName).Single().PkId;
      }

      public List<ProductType> GetShopProductTypesByShopId(Guid shopId)
      {
        return _context.producttypes.Where(t => t.ShopId == shopId).ToList();
      }

      public Guid AddShopProduct(Product product)
      {
        _context.products.Add(product);

        _context.SaveChanges();

        return _context.products.Where(p => p.PkId == product.PkId).SingleOrDefault().PkId;
      }
    }
}