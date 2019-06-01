using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using MediatR;
using System.Runtime.Serialization;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class EditShopTypeCommand : IRequest<ShopType>
  {
    public string PkId { get; set; }

    public string Name { get; set; }

    public string Img { get; set; }

    public EditShopTypeCommand (string pkId, string name, string img)
    {
      PkId = pkId;
      Name = name;
      Img = img;
    }
  }
}