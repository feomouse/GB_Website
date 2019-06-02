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

      public int CreateShopType(ShopType shopType)
      {
         _context.shopTypes.Add(shopType);

         return _context.SaveChanges();
      }

      public IList<ShopType> GetShopTypeInfo()
      {
         return _context.shopTypes.ToList();
      }

      public ShopType EditShopType(ShopType newShopType)
      {
        var type = _context.shopTypes.Where(st => st.PkId == newShopType.PkId).FirstOrDefault();
        type.SetName(newShopType.Name);
        type.SetImg(newShopType.Img);

        if(_context.SaveChanges() != 0)
        {
          return newShopType;
        }

        return null;
      }

      public ShopType GetShopTypeByPkId(string pkId)
      {
        return _context.shopTypes.Where(st => st.PkId.ToString() == pkId).FirstOrDefault();
      }

      public int CreateShop(Shop newShop)
      {
        _context.shops.Add(newShop);

        return _context.SaveChanges();
      }
      
      public int AddShopToShopType(string shopTypeId, Shop shop)
      {
        _context.shopTypes.Where(st => st.PkId.ToString() == shopTypeId).FirstOrDefault().Shops.Add(shop);

        return _context.SaveChanges();
      }

      public IList<Shop> GetShopsByNameAndCity(string shopName, string province, string city)
      {
        return _context.shops.Where(s => (s.Name.Contains(shopName) && s.Province == province && s.City == city)).ToList();
      }

      public IList<Shop> GetShopsByMerchantIds(IList<string> merchantIds)
      {
        IList<Shop> shops = new List<Shop>();

        foreach(var i in merchantIds)
        {
          shops.Add(_context.shops.Where(s => s.RegisterId.ToString() == i).FirstOrDefault());
        }

        return shops;
      }

      public Shop GetShopByName(string shopName)
      {
        return _context.shops.Where(s => s.Name == shopName).FirstOrDefault();
      }

      public Shop GetShopByNameAndCity(string shopName, string province, string city)
      {
        return _context.shops.Where(s => (s.Name == shopName && s.Province == province && s.City == city)).FirstOrDefault();
      }

      public Shop GetShopByShopId(string shopId)
      {
        return _context.shops.Where(s => s.PkId.ToString() == shopId).FirstOrDefault();
      }

      public List<Shop> GetShopListByShopTypeAndCity(string province, string city, ShopType shopType, int page)
      {
        return _context.shops.Where(s => (s.Type == shopType && s.Province == province && s.City == city)).Skip((page-1)*10).Take(10).ToList();
      }
      
      public bool CheckIfIdentitied(string shopId)
      {
        return _context.shops.Where(b => b.PkId.ToString() == shopId).FirstOrDefault().IsIdentitied;
      }

      public Shop GetShopByMerchantId(string merchantId)
      {
        return _context.shops.Where(b => b.RegisterId.ToString() == merchantId).FirstOrDefault();
      }

      public Shop GetShopByMerchantIdAndShopId(string merchantId, string shopId)
      {
        return _context.shops.Where(s => (s.PkId.ToString() == shopId && s.RegisterId.ToString() == merchantId)).FirstOrDefault();
      }

      public int IdentityMerchantOfShop(string merchantId, string shopId, bool isChecked)
      {
        var shop = GetShopByMerchantIdAndShopId(merchantId, shopId);
      
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

      public List<GBProduct> GetGBProductsByShopName(string shopName, string province, string city)
      {
        Shop shop = _context.shops.Where(b => (b.Name == shopName && b.Province == province && b.City == city)).FirstOrDefault();

        if(shop == null) return null;

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
      
        _context.SaveChanges();

        return _context.gbproduct.Where(b => b.PkId == newgbProduct.PkId).FirstOrDefault();
      }

      public int DeleteGBProduct(string gbProductName)
      {
        GBProduct gbProduct = _context.gbproduct.Where(b => b.ProductName == gbProductName).FirstOrDefault();
        _context.gbproduct.Remove(gbProduct);

        return _context.SaveChanges();
      }

      public int DeleteGBProductById(string gbProductId)
      {
        var imgs = _context.gbProductImg.Where(bi => bi.MGBProductId.ToString() == gbProductId).ToList();

        foreach(var i in imgs)
        {
          _context.gbProductImg.Remove(i);
        }

        _context.Remove(_context.gbproduct.Where(b => b.PkId.ToString() == gbProductId).FirstOrDefault());
        return _context.SaveChanges();
      }

      public List<ProductType> GetShopProductTypesByShopName(string shopName, string province, string city)
      {
        var shop = _context.shops.Where(b => (b.Name == shopName && b.Province == province && b.City == city)).FirstOrDefault();
        return shop == null ?  new List<ProductType>() : _context.producttypes.Where(t => t.ShopId == shop.PkId).ToList();
      }

      public int DeleteProductType(string productTypePkId)
      {
        var productType = _context.producttypes.Where(t => t.PkId.ToString() == productTypePkId).FirstOrDefault();

        _context.producttypes.Remove(productType);
      
        return _context.SaveChanges();
      }

      public Shop UpdateShop (string pkId, string name, string province, string city, string district, string location, string tel)
      {
        var oldShop = _context.shops.Where(t => t.PkId.ToString() == pkId).FirstOrDefault();

        oldShop.SetName(name);
        oldShop.SetProvince(province);
        oldShop.SetCity(city);
        oldShop.SetDistrict(district);
        oldShop.SetLocation(location);
        oldShop.SetTel(tel);

        _context.SaveChanges();

        return _context.shops.Where(t => t.PkId.ToString() == pkId).FirstOrDefault();
      }

      public string GetGBProductKeyByName (string gbProductName)
      {
        var product = _context.gbproduct.Where(b => b.ProductName == gbProductName).FirstOrDefault();

        if(product == null) return "";

        return product.PkId.ToString();
      }

      public List<GBProduct> GetGBProductsByProductId (string productTypeId)
      {
        return _context.gbproduct.Where(b => b.ProductTypeId.ToString() == productTypeId).ToList();
      }

      public List<Shop> GetShopListByCity(string province, string city)
      {
        return _context.shops.Where(t => (t.Province == province && t.City == city)).ToList();
      }

      public bool IncreGBPayAmount (string gbProductName, string shopName, int itemCost, int number)
      {
        var tempGB = _context.gbproduct.Where(b => (b.ProductName == gbProductName && b.Price == itemCost)).ToList();

        foreach(GBProduct i in tempGB)
        {
          if(_context.shops.Where(b => b.PkId == (_context.producttypes.Where(c => c.PkId == i.ProductTypeId).FirstOrDefault().ShopId)).FirstOrDefault().Name == shopName)
          {
            i.IncreMSellNum(number);
            return (_context.SaveChanges() != 0);
          }
        }
        return false;
      }

      public int GetShopsTotalCount(string province, string city, ShopType shopType)
      {
        return _context.shops.Where(s => (s.Province == province && s.City == city && s.Type == shopType)).ToList().Count;
      }

      public int SetMerchantToShop(Guid shopId, Guid merchantId)
      {
        _context.shops.Where(s => s.PkId.ToString() == shopId.ToString()).FirstOrDefault().SetRegisterId(merchantId);

        return _context.SaveChanges();
      }

      public IList<Shop> GetShopsByMerchantId(string merchantId)
      {
        return _context.shops.Where(s => s.RegisterId.ToString() == merchantId).ToList();
      }

      public IList<ShopImg> GetShopImgs(string shopId)
      {
        return _context.shopImgs.Where(s => s.MShopId.ToString() == shopId).ToList();
      }

      public int CreateShopImg(string shopId, string img)
      {
        Shop shop = _context.shops.Where(s => s.PkId.ToString() == shopId).FirstOrDefault();

        _context.shopImgs.Add(new ShopImg(shop, img));
      
        return _context.SaveChanges();
      }

      public IList<GBProductImg> GetGBProductImgs(string gbProductId)
      {
        return _context.gbProductImg.Where(g => g.MGBProductId.ToString() == gbProductId).ToList();
      }

      public int CreateGBProductImg(string gbProductId, string img)
      {
        GBProduct gbProduct = _context.gbproduct.Where(g => g.PkId.ToString() == gbProductId).FirstOrDefault();

        _context.gbProductImg.Add(new GBProductImg(gbProduct, img));

        return _context.SaveChanges();
      }
    }
}