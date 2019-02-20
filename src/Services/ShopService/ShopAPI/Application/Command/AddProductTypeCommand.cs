using System.Runtime.Serialization;
using MediatR;
using System;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
  [DataContract]
  public class AddProductTypeCommand : IRequest<int>
  {
     
    [DataMember]
    public Guid ShopId { get; private set; }

    [DataMember]
    public string TypeName { get; private set; }

    public AddProductTypeCommand ( Guid shopId, string typeName )
    {
      ShopId = shopId;
      TypeName = typeName;
    }
  }
}