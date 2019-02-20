using System.Runtime.Serialization;
using MediatR;
using System;

namespace GB_project.Services.ShopService.ShopAPI.Application.Command
{
  [DataContract]
  public class CreateShopCommand : IRequest<int>
  {
    [DataMember]
    public string Name { get; private set; }

    [DataMember]
    public string Province { get; private set; }

    [DataMember]
    public string City { get; private set; }

    [DataMember]
    public string District { get; private set; }

    [DataMember]
    public string Location { get; private set; }

    [DataMember]
    public Guid Type { get; private set; }

    [DataMember]
    public string Tel { get; private set; }

    [DataMember]
    public Guid Manager { get; private set; }

    [DataMember]
    public string Pic { get; private set; }

    public CreateShopCommand()
    {

    }
    public CreateShopCommand (string name, string province, string city, string district, string location, Guid type, string tel, Guid manager, string pic)
    {
      Name = name;
      Province = province;
      City = city;
      District = district;
      Location = location;
      Type = type;
      Tel = tel;
      Manager = manager;
      Pic = pic;
    }
  }
}