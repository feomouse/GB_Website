using System;
using System.Runtime.Serialization;
using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
    [DataContract]
    public class AddGBProductCommand : IRequest<int>
    {
      [DataMember]
      public string ProductTypeId { get; set; }
      [DataMember]
      public string ProductName { get; set; }
      [DataMember]
      public string OrinPrice { get; set; }
      [DataMember]
      public string Price { get; set; }
      [DataMember]
      public string Quantity { get; set; }
      [DataMember]
      public string VailSDate { get; set; }
      [DataMember]
      public string VailEDate { get; set; }
      [DataMember]
      public string VailTime { get; set; }
      [DataMember]
      public string Img { get; set; }
      [DataMember]
      public string Remark { get; set; }

      public AddGBProductCommand ( string productTypeId, string productName, string orinPrice, string price, string quantity, string vailSDate, string vailEDate, string vailTime, string img, string remark)
      {
        ProductTypeId = productTypeId;
        ProductName = productName;
        OrinPrice = orinPrice;
        Price = price;
        Quantity = quantity;
        VailSDate = vailSDate;
        VailEDate = vailEDate;
        VailTime = vailTime;
        Img = img;
        Remark = remark;
      } 
    }
}