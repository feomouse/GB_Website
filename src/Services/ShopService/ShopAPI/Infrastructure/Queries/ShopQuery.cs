using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Linq;
using System;
using System.Collections.Generic;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
  public class ShopQuery : IShopQuery
  {
    IShopRepository _repo;

    public ShopQuery (IShopRepository repo)
    {
      _repo = repo;
    }

    public Shop getShopByName(string name)
    {
      return _repo.GetShopByName(name);
    }

    public Shop getShopByMerchantId( string merchantId)
    {
      return _repo.GetShopByMerchantId(merchantId);
    }

    public List<Shop> getShopListByShopType(int shopType)
    {
      return _repo.GetShopListByShopType(shopType);
    }

    public List<GBProduct> getGBProductsByShopName( string shopName)
    {
      return _repo.GetGBProductsByShopName(shopName);
    }

    public List<ProductType> getShopProductTypesByShopName(string shopName)
    {
      return _repo.GetShopProductTypesByShopName(shopName);
    }

    public string getGBProductByName(string name)
    {
      return _repo.GetGBProductKeyByName(name);
    }
/* 
    public Product getProductByName(string name) 
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Shop;User=sa;Password=107409;"))
      {
        var result = connection.Query<Product>(
          @"SELECT [shop].[Product].[PkId] AS PkId, [shop].[Product].[ProductName] AS ProductName, 
          [shop].[Product].[ProductTypeId] AS ProductTypeId, [shop].[Product].[ProductImg] AS ProductImg, [shop].[Product].[ProductPrice] AS ProductPrice, 
          [shop].[Product].[MSellNum] AS MSellNum, [shop].[Product].[PraiseNum] AS PraiseNum, [shop].[Product].[IsDisplay] AS IsDisplay
          FROM [shop].[Product] WHERE [shop].[Product].[ProductName] = @Name", new { Name = name}
        ).First();
        return result;
      }
    } */

/*     public List<Product> GetShopProductsByShopName(string shopName)
    {
       return _repo.GetShopProductsByShopName(shopName);
    }

 */
/* 
    public GBProduct getGBProductByName( string name )
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Shop;User=sa;Password=107409;"))
      {
        var result = connection.Query<GBProduct>(
          @"SELECT GBProduct.[PkId] AS PkId, GBProduct.[ProductName] AS ProductName, GBProduct.[OrinPrice] AS OrinPrice,
          GBProduct.[Price] AS Price, GBProduct.[Quantity] AS Quantity, GBProduct.[VailSDate] AS VailSDate, GBProduct.[VailEDate] AS VailEDate,
          GBProduct.[VailTime] AS VailTime, GBProduct.[Img] AS Img, GBProduct.[Remark] AS Remark, GBProduct.[ShopId] AS ShopId
          FROM GBProduct WHERE GBProduct.[ProductName] = @Name", new { Name = name}
        ).First();
        return result;
      }
    }

    public GBProductItem getGBProductItemByGbIdAndName( Guid gbid, string name)
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Shop;User=sa;Password=107409;"))
      {
        var result = connection.Query<GBProductItem>(
          @"SELECT GBProductItem.[PkId] AS PkId, GBProductItem.[GbProductId] AS GbProductId, GBProductItem.[GbItemName] AS GbItemName, 
          GBProductItem.[GbItemImg] AS GbItemImg, GBProductItem.[GbItemPrice] AS GbItemPrice
          FROM GBProductItem WHERE GbProductId = @GbId AND GbItemName = @Name;", new {GbId = gbid, Name = name}
        ).First();
        return result;
      }
    }

    public GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId)
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Shop;User=sa;Password=107409;"))
      {
        var result = connection.Query<GBRule>(
          @"SELECT GBRule.[PkId], GBRule.[GBProductId], GBRule.[Content] FROM GBRule WHERE GBProductId = @gbid AND Content = @con", 
          new { gbid = gbProId, con = content}
        ).First();
        return result;
      }
    } */
  }
}