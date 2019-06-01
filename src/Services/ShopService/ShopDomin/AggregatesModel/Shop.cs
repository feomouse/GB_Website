using System.Collections.Generic;
using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class Shop : Entity, IAggregateRoot {
    public Guid PkId { get; private set; }

    public string Name { get; private set; }

    public string Province { get; private set; }

    public string City { get; private set; }

    public string District { get; private set; }

    public string Location { get; private set; }

    public Guid ShopTypePkId { get; private set; }
    public ShopType Type { get; private set; }

    public string Tel { get; private set; }

    public Guid RegisterId { get; private set; }

    public bool IsIdentitied { get; private set; }

    public bool GroupBuying { get; private set; }

    public int OwnMoney { get; private set; }

    public string WorkingTime { get; private set; }

    public List<ShopImg> Imgs { get; private set; }

/*     public List<ProductType> _producttype { get; set; } */

    public Shop () {

    }

    public Shop(string name, string province, string city, string district, string location, string tel)
    {
       PkId = new Guid();
       Name = name;
       Province = province;
       City = city;
       District = district;
       Location = location;
       Tel = tel;
       IsIdentitied = false;
       GroupBuying = false;
       OwnMoney = 0;
    }

    public void SetPkId(Guid pkId)
    {
      PkId = pkId;
    }

    public void SetName(string name)
    {
      Name = name;
    }

    public void SetProvince(string province)
    {
      Province = province;
    }

    public void SetCity(string city)
    {
      City = city;
    }

    public void SetDistrict(string district)
    {
      District = district;
    }

    public void SetLocation(string location)
    {
      Location = location;
    }

    public void SetType(ShopType type)
    {
      Type = type;
    }

    public void SetTel(string tel)
    {
      Tel = tel;
    }

    public void SetIsIdentitied(bool isIdentitied)
    {
      IsIdentitied = isIdentitied;
    }

    public void SetGroupBuying(bool result)
    {
      GroupBuying = result;
    }

    public void SetOwnMoney(int money)
    {
      OwnMoney = money;
    }

    public void SetWorkingTime(string time)
    {
      WorkingTime = time;
    }

    public void SetRegisterId(Guid id)
    {
      RegisterId = id;
    }
  }
}