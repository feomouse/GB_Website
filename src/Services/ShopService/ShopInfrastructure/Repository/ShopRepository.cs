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

      public List<GBProduct> GetGBProductsByShopName(string shopName, string province, string city, string district)
      {
        Shop shop = _context.shops.Where(b => (b.Name == shopName && b.Province == province && b.City == city && b.District == district)).FirstOrDefault();

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

      public List<ProductType> GetShopProductTypesByShopName(string shopName, string province, string city, string district)
      {
        var shop = _context.shops.Where(b => (b.Name == shopName && b.Province == province && b.City == city && b.District == district)).FirstOrDefault();
        return shop == null ?  new List<ProductType>() : _context.producttypes.Where(t => t.ShopId == shop.PkId).ToList();
      }

      public int DeleteProductType(string productTypePkId)
      {
        var productType = _context.producttypes.Where(t => t.PkId.ToString() == productTypePkId).FirstOrDefault();

        _context.producttypes.Remove(productType);
      
        return _context.SaveChanges();
      }

      public Shop UpdateShop (string pkId, string name, string province, string city, string district, string location, string tel, string workingTime)
      {
        var oldShop = _context.shops.Where(t => t.PkId.ToString() == pkId).FirstOrDefault();

        oldShop.SetName(name);
        oldShop.SetProvince(province);
        oldShop.SetCity(city);
        oldShop.SetDistrict(district);
        oldShop.SetLocation(location);
        oldShop.SetTel(tel);
        oldShop.SetWorkingTime(workingTime);

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

      public IList<Shop> GetShopsByDistrictAndType(string province, string city, string district, string shopTypeId, int page)
      {
        return _context.shops.Where(s => (s.Province == province && s.City == city && 
                             s.District == district && s.ShopTypePkId.ToString() == shopTypeId)).Skip((page-1)*10).Take(10).ToList();
      }

      public IList<Shop> GetRandomShopsByCityAndType(string province, string city, string shopTypeId)
      {
        var r = new Random();
        var startVal = 0;
        if(_context.shops.Count()-6 > 0) startVal = r.Next(_context.shops.Count()-6);
        else startVal = 0;
        return _context.shops.
                Where(s => (s.Province == province && s.City == city && s.ShopTypePkId.ToString() == shopTypeId)).
                Skip(startVal).
                Take(6).
                ToList();
      }

      public int GetShopsNumByDistrictAndShopType(string province, string city, string district, string shopTypeId)
      {
        return _context.shops.Count(s => (s.Province == province && s.City == city && s.District == district && s.ShopTypePkId.ToString() == shopTypeId));
      }

      public int IncreaseVisitNum(string shopId, string year, string month)
      {
        var result = _context.visitNums.Where(vn => (vn.MShopId.ToString() == shopId && vn.Year == year && vn.Month == month)).FirstOrDefault();
      
        if(result == null) 
        {
          _context.visitNums.Add(new VisitNum(_context.shops.Where(s => s.PkId.ToString() == shopId).FirstOrDefault(), year, month, 1));
        }

        else 
        {
          result.IncreaseNum();
        }
        return _context.SaveChanges();
      }

      public int IncreaseMonthSell(string shopId, string year, string month, int num)
      {
        var result = _context.monthSells.Where(vn => (vn.MShopId.ToString() == shopId && vn.Year == year && vn.Month == month)).FirstOrDefault();
      
        if(result == null) 
        {
          _context.monthSells.Add(new MonthSell(_context.shops.Where(s => s.PkId.ToString() == shopId).FirstOrDefault(), year, month, num));
        }

        else 
        {
          result.IncreaseMonthSell(num);
        }
        return _context.SaveChanges();
      }

      public dynamic GetVisitNumsByYear(string shopId, string year)
      {
        return _context.visitNums.
                      Where(vn => (vn.MShopId.ToString() == shopId && vn.Year == year)).
                      OrderBy(vn => Int32.Parse(vn.Month)).
                      Select(vn => new {month = vn.Month, num = vn.Num}).
                      ToList();
      }

      public dynamic GetMonthSellsByYear(string shopId, string year)
      {
        return _context.monthSells.
                      Where(ms => (ms.MShopId.ToString() == shopId && ms.Year == year)).
                      OrderBy(ms => Int32.Parse(ms.Month)).
                      Select(ms => new {month = ms.Month, num = ms.Num}).
                      ToList();
      }

      public int DeleteShopType(string shopTypeId)
      {
        var shopType = _context.shopTypes.Where(st => st.PkId.ToString() == shopTypeId).FirstOrDefault();

        var shops = _context.shops.Where(s => s.ShopTypePkId.ToString() == shopType.PkId.ToString()).ToList();

        foreach(var i in shops)
        {
          foreach(var k in i.Imgs)
          {
            _context.shopImgs.Remove(k);
          }
          foreach(var h in i.VisitNums)
          {
            _context.visitNums.Remove(h);
          }
          foreach(var p in i.MonthSells)
          {
            _context.monthSells.Remove(p);
          }

          var pts = _context.producttypes.Where(d => d.ShopId.ToString() == i.PkId.ToString()).ToList();

          foreach(var j in pts)
          {
            var gbs = _context.gbproduct.Where(c => c.ProductTypeId.ToString() == j.PkId.ToString()).ToList();

            foreach(var z in gbs)
            {
              foreach(var m in z.Imgs)
              {
                _context.gbProductImg.Remove(m);
              }
              _context.gbproduct.Remove(z);
            }
            _context.producttypes.Remove(j);
          }

          _context.shops.Remove(i);
        }

        _context.shopTypes.Remove(shopType);

        return _context.SaveChanges();
      }
    }
}