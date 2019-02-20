using System.Runtime.Serialization;
using MediatR;
using System;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
  [DataContract]
  public class AddProductCommand : IRequest<int>
  {
    [DataMember]
    public Guid ShopId { get; private set; }
    [DataMember]
    public string ProductName { get; private set; }

    [DataMember]
    public Guid ProductType { get; private set; }

    [DataMember]
    public string ProductImg { get; private set; }

    [DataMember]
    public int ProductPrice { get; private set; }

    [DataMember]
    public int MSellNum { get; private set; }

    [DataMember]
    public int PraiseNum { get; private set; }

    [DataMember]
    public bool IsDisplay { get; private set; }

    public AddProductCommand ( Guid shopId, string productName, Guid productType, string productImg , int productPrice, bool isDisplay)
    {
      ShopId = shopId;
      ProductName = productName;
      ProductType = productType;
      ProductImg = productImg;
      ProductPrice = productPrice;
      MSellNum = 0;
      PraiseNum = 0;
      IsDisplay = isDisplay;
    }
  }
}