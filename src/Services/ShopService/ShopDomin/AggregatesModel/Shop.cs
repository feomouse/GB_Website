using System.Collections.Generic;
using GB_project.Services.ShopService.ShopDomin.SeedWork;
using System;

namespace GB_project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class Shop : Entity, IAggregateRoot {
    public Guid PkId { get; private set; }

    public string Name { get; private set; }

    public string Province { get; private set; }

    public string City { get; private set; }

    public string District { get; private set; }

    public string Location { get; private set; }

    public Guid Type { get; private set; }

    public string Tel { get; private set; }

    public Guid Manager { get; private set; }

    public string Pic { get; private set; }

    public List<GBProduct> GbProduct { get; set; }

    public List<Product> _product { get; set; }

    public List<ProductType> _producttype { get; set; }

    public List<ShopMerchant> _shopmerchant { get; set; }

    public Shop () {

    }

    public Shop(string name, string province, string city, string district, string location, Guid type, string tel, Guid manager, string pic)
    {
       PkId = new Guid();
       Name = name;
       Province = province;
       City = city;
       District = district;
       Location = location;
       Type = type;
       Tel = tel;
       Manager = manager;
       Pic = pic;
    }
  }
}