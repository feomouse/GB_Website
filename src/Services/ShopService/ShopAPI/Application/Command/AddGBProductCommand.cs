using System;
using System.Runtime.Serialization;
using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Command
{
    [DataContract]
    public class AddGBProductCommand : IRequest<int>
    {
      [DataMember]
      public Guid ShopId { get; private set; }

      [DataMember]
      public string ProductName { get; private set; }
      [DataMember]
      public int OrinPrice { get; private set; }
      [DataMember]
      public int Price { get; private set; }
      [DataMember]
      public string Quantity { get; private set; }
      [DataMember]
      public DateTime VailSDate { get; private set; }
      [DataMember]
      public DateTime VailEDate { get; private set; }
      [DataMember]
      public string VailTime { get; private set; }
      [DataMember]
      public string Img { get; private set; }
      [DataMember]
      public string Remark { get; private set; }

      public AddGBProductCommand ( Guid shopId, string productName, int orinPrice, int price, string quantity, DateTime vailSDate, DateTime vailEDate, string vailTime, string img, string remark)
      {
        ShopId = shopId;
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