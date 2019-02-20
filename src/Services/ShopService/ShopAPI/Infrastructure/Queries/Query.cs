using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;
using System.Linq;
using System;

namespace GB_project.Services.ShopService.ShopAPI.Infrastructure.Queries
{
  public class readQuery : IQuery
  {
    public Shop getShopByName(string name)
    {
      using (var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
      {
        connection.Open();

        var result = connection.Query<Shop>(
          @"SELECT shop.[PkId] as PkId, shop.[Name] as Name, shop.[Province] as Province, shop.[City] as City, 
          shop.[District] as District, shop.[Location] as Location, shop.[Type] as Type, shop.[Tel] as Tel, 
          shop.[Manager] as Manager, shop.[Pic] as Pic FROM shop.shop WHERE shop.[Name] = @Name;",
          new { Name = name }
        ).First();

        return result;
      }
    }

    public ShopMerchant getShopMerchantByKey( Guid merchantId, Guid shopId )
    {
      using (var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
      {
        connection.Open();

        var result = connection.Query<ShopMerchant>(
          @"SELECT shopMerchant.[MerchantId] AS MerchantId, shopMerchant.[ShopId] AS ShopId, shopMerchant.[IsRegister] AS IsRegister 
          FROM shopMerchant WHERE shopMerchant.[MerchantId] = @Merchant AND shopMerchant.[ShopId] = @ShopId;",
          new { MerchantId = merchantId, ShopId = shopId }
        ).First();

        return result;
      }
    }

    public Product getProductByName(string name) 
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
      {
        var result = connection.Query<Product>(
          @"SELECT Product.[PkId] AS PkId, Product.[ShopId] AS ShopId, Product.[ProductName] AS ProductName, 
          Product.[ProductType] AS ProductType, Product.[ProductImg] AS ProductImg, Product.[ProductPrice] AS ProductPrice, 
          Product.[MSellNum] AS MSellNum, Product.[PraiseNum] AS PraiseNum, Product.[IsDisplay] AS IsDisplay
          FROM Product WHERE Product.[ProductName] = @Name", new { Name = name}
        ).First();
        return result;
      }
    }

    public GBProduct getGBProductByName( string name )
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
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
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
      {
        var result = connection.Query<GBProductItem>(
          @"SELECT GBProductItem.[PkId] AS PkId, GBProductItem.[GbProductId] AS GbProductId, GBProductItem.[GbItemName] AS GbItemName, 
          GBProductItem.[GbItemImg] AS GbItemImg, GBProductItem.[GbItemPrice] AS GbItemPrice
          FROM GBProductItem WHERE GbProductId = @GbId AND GbItemName = @Name;", new {GbId = gbid, Name = name}
        ).First();
        return result;
      }
    }

    public ProductType getProductTypeByNameAndShopId(string name, Guid shopId)
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
      {
        var result = connection.Query<ProductType>(
          @"SELECT ProductType.[PkId] AS PkId, ProductType.[ShopId] AS ShopId, ProductType.[TypeName] AS TypeName 
          FROM ProductType WHERE ShopId = @ShopId, TypeName = @TypeName", new {ShopId = shopId, TypeName = name}
        ).First();
        return result;
      }
    }

    public GBRule getGBRuleByContentAndGBProductId(string content, Guid gbProId)
    {
      using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=SHOP;Trusted_Connection=True;"))
      {
        var result = connection.Query<GBRule>(
          @"SELECT GBRule.[PkId], GBRule.[GBProductId], GBRule.[Content] FROM GBRule WHERE GBProductId = @gbid AND Content = @con", 
          new { gbid = gbProId, con = content}
        ).First();
        return result;
      }
    }
  }
}
