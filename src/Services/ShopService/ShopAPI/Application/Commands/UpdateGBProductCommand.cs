using System.Runtime.Serialization;
using MediatR;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  [DataContract]
  public class UpdateGBProductCommand : IRequest<GBProduct>
  {
      [DataMember]
      public string GBProductId { get; set; }
      [DataMember]
      public string ProductTypeId { get; set; }
      [DataMember]
      public string ProductName { get; set; }
      [DataMember]
      public string OrinPrice { get; set; }
      [DataMember]
      public string Price { get; set; }
      [DataMember]
      public string Quantity { get; set; }
      [DataMember]
      public string VailSDate { get; set; }
      [DataMember]
      public string VailEDate { get; set; }
      [DataMember]
      public string VailTime { get; set; }
      [DataMember]
      public string Img { get; set; }
      [DataMember]
      public string Remark { get; set; }
  }
}