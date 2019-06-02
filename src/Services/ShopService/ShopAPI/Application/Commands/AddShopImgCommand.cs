using System;
using System.Runtime.Serialization;
using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
    [DataContract]
    public class AddShopImgCommand : IRequest<int>
    {
      [DataMember]
      public string ShopId { get; set; }
      [DataMember]
      public string Img { get; set; }

      public AddShopImgCommand (string shopId, string img )
      {
        ShopId = shopId;
        Img = img;
      } 
    }
}