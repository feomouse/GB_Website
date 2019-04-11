using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class DeleteGBProductCommand : IRequest<int>
  {
    public string GBProductName {get; set; }

    public DeleteGBProductCommand(string name)
    {
      GBProductName = name;
    }
  }
}