using System;
using System.Runtime.Serialization;
using MediatR;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
    [DataContract]
    public class AddGBRuleCommand : IRequest<int>
    {
      [DataMember]
      public Guid GBProductId { get; private set; }

      [DataMember]
      public string Content { get; private set; } 

      public AddGBRuleCommand ( Guid gBProductId, string content )
      {
        GBProductId = gBProductId;
        Content = content;
      }
    }
}