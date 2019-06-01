using System.Runtime.Serialization;
using MediatR;
using System;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  [DataContract]
  public class AddShopTypeCommand : IRequest<int>
  {
    [DataMember]
    public string TypeName { get; private set; }

    public string Img { get; private set; }

    public AddShopTypeCommand ( string typeName, string img)
    {
      TypeName = typeName;
      Img = img;
    }
  }
}