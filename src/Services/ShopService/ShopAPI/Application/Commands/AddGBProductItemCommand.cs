using System;
using System.Runtime.Serialization;
using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
    [DataContract]
    public class AddGBProductItemCommand : IRequest<int>
    {
      [DataMember]
      public Guid GbProductId { get; private set; }

      [DataMember]
      public string GbItemName { get; private set; }

      [DataMember]
      public string GbItemImg { get; private set; }

      [DataMember]
      public int GbItemPrice { get; private set; }


      public AddGBProductItemCommand ( Guid gbProductId, string gbItemName, string gbItemImg, int gbItemPrice)
      {
        GbProductId = gbProductId;
        GbItemName = gbItemName;
        GbItemImg = gbItemImg;
        GbItemPrice = gbItemPrice;
      }
    }
}