using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using GB_Project.Services.ShopService.ShopInfrastructure.Context;
using System.IO;

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
        return _context.shops.Where(s => s.Name == shopName).FirstOrDefault();
      }

      public Shop GetShopByShopId(string shopId)
      {
        return _context.shops.Where(s => s.PkId.ToString() == shopId).FirstOrDefault();
      }
      
      public bool CheckIfIdentitied(string shopId)
      {
        return _context.shops.Where(b => b.PkId.ToString() == shopId).FirstOrDefault().IsIdentitied;
      }

      public Shop GetShopByMerchantId(string merchantId)
      {
        return _context.shops.Where(b => b.RegisterId.ToString() == merchantId).FirstOrDefault();
      }

      public int IdentityMerchantOfShop(string merchantId, bool isChecked)
      {
        var shop = GetShopByMerchantId(merchantId);
      
        if(shop == null) throw new Exception();
        shop.SetIsIdentitied(isChecked);

        return _context.SaveChanges();
      }

      public int SetGB(string shopId)
      {
        Shop shop = _context.shops.Where(b => b.PkId.ToString() == shopId).FirstOrDefault();

        shop.SetGroupBuying(true);

        return _context.SaveChanges();
      }

      public int CreateShopProductType(ProductType type)
      {
        _context.producttypes.Add(type);

        return _context.SaveChanges();
      }

      public ProductType GetProductTypeByProductTypeId(string productTypeId)
      {
        return _context.producttypes.Where(b => b.PkId.ToString() == productTypeId).FirstOrDefault();
      }

      public int AddGBProduct(GBProduct newgbProduct)
      {
        _context.gbproduct.Add(newgbProduct);

        return _context.SaveChanges();
      }

      public List<GBProduct> GetGBProductsByShopName(string shopName)
      {
        Shop shop = _context.shops.Where(b => b.Name == shopName).FirstOrDefault();

        ProductType[] types = _context.producttypes.Where(b => b._Shop == shop).ToArray();

        List<GBProduct> gbProducts = new List<GBProduct>();

        foreach(var t in types)
        {
          gbProducts.AddRange(_context.gbproduct.Where(b => b.ProductType == t).ToList());
        }

        return gbProducts;
      }

      public GBProduct UpdateGBProducts(GBProduct newgbProduct)
      {
        GBProduct gbProduct = _context.gbproduct.Where(b => b.PkId == newgbProduct.PkId).FirstOrDefault();
      
        gbProduct.SetProductName(newgbProduct.ProductName);
        gbProduct.SetProductType(newgbProduct.ProductType);
        gbProduct.SetOrinPrice(newgbProduct.OrinPrice);
        gbProduct.SetPrice(newgbProduct.Price);
        gbProduct.SetQuantity(newgbProduct.Quantity);
        gbProduct.SetRemark(newgbProduct.Remark);
        gbProduct.SetVailSDate(newgbProduct.VailSDate);
        gbProduct.SetVailEDate(newgbProduct.VailEDate);
        gbProduct.SetVailTime(newgbProduct.VailTime);
        gbProduct.SetIsDisplay(newgbProduct.IsDisplay);
        gbProduct.SetImg(newgbProduct.Img);
      
        _context.SaveChanges();

        return _context.gbproduct.Where(b => b.PkId == newgbProduct.PkId).FirstOrDefault();
      }

      public string UploadShopImg(Shop shop, string imgName, byte[] imgData)
      {
          File.WriteAllBytes("D:\\nginx-1.12.2\\nginx-1.12.2\\IMGS\\shops\\" + imgName, imgData);

          string imgLocation = "http://localhost:50020/ShopImgs/" + imgName;

          shop.SetPic(imgLocation);

          if(_context.SaveChanges() == 0)
          {
            return "";
          }

          return imgLocation;
      }
/*       public List<Shop> GetShops()
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
      } */
    }
}