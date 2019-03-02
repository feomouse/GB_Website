using System;
using System.Runtime.Serialization;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Command
{
    [DataContract]
    public class AddMerchantCommand : IRequest<int>
    {
      [DataMember]
      public Guid MerchantId { get; private set; }

      [DataMember]
      public Guid ShopId {get; private set; } 

      [DataMember]
      public bool IsRegister { get; private set; }

      public AddMerchantCommand ( Guid merchantId, Guid shopId, bool isRegister )
      {
        MerchantId = merchantId;
        ShopId = shopId;
        IsRegister = isRegister;
      }
    }
}