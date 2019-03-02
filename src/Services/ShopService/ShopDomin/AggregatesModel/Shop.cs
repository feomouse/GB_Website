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

    public int Type { get; private set; }

    public string Tel { get; private set; }

    public Guid RegisterId { get; private set; }

    public string Pic { get; private set; }

    public List<GBProduct> _gbProduct { get; set; }

    public List<ProductType> _producttype { get; set; }

    public Shop () {

    }

    public Shop(string name, string province, string city, string district, string location, int type, string tel, Guid registerId, string pic)
    {
       PkId = new Guid();
       Name = name;
       Province = province;
       City = city;
       District = district;
       Location = location;
       Type = type;
       Tel = tel;
       RegisterId = registerId;
       Pic = pic;
    }

    public void SetPkId(Guid pkId)
    {
      PkId = pkId;
    }
  }
}