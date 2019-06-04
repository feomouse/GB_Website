using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using MediatR;
using System.Runtime.Serialization;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class EditShopCommand : IRequest<Shop>
  {
    [DataMember]
    public string PkId { get; private set; }

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
    public string Tel { get; private set; }

    [DataMember]
    public string WorkingTime { get; private set; }


    public EditShopCommand (string pkId, string name, string province, string city, string district, string location, string tel, string workingTime)
    {
      PkId = pkId;
      Name = name;
      Province = province;
      City = city;
      District = district;
      Location = location;
      Tel = tel;
      WorkingTime = workingTime;
    }
  }
}