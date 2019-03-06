using System.Runtime.Serialization;
using MediatR;
using System;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  [DataContract]
  public class AddProductTypeCommand : IRequest<int>
  {
     
    [DataMember]
    public string ShopId { get; private set; }

    [DataMember]
    public string TypeName { get; private set; }

    public AddProductTypeCommand ( string shopId, string typeName )
    {
      ShopId = shopId;
      TypeName = typeName;
    }
  }
}