using GB_Project.Services.ShopService.ShopDomin.SeedWork;
using System.Collections.Generic;
using System;

namespace GB_Project.Services.ShopService.ShopDomin.AggregatesModel
{
  public class GBRule : Entity
  {
    public Guid PkId { get; private set; }

    public Guid GBProductId { get; private set; }

    public GBProduct _GBProduct { get; private set; }
 
    public string Content { get; private set; } 

    public GBRule ()
    {

    }
    
    public GBRule (GBProduct gBProduct, string content)
    {
      PkId = new Guid();

      _GBProduct = gBProduct;
      
      Content = content;
    }
  }   
}