using System;
using System.Runtime.Serialization;
using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
    [DataContract]
    public class AddGBProductImgCommand : IRequest<int>
    {
      [DataMember]
      public string GBProductId { get; set; }
      [DataMember]
      public string Img { get; set; }

      public AddGBProductImgCommand (string gbProductId, string img)
      {
        GBProductId = gbProductId;
        Img = img;
      } 
    }
}