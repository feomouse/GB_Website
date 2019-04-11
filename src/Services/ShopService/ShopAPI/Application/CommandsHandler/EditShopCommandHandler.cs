using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class EditShopCommandHandler : IRequestHandler<EditShopCommand, Shop>
  {
    private IShopRepository _repo;

    public EditShopCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<Shop> Handle(EditShopCommand request, CancellationToken cancellationToken)
    {
      Shop newshop = new Shop(request.Name, request.Province, request.City, request.District, request.Location, request.Type, 
                             request.Tel, new Guid(request.Manager), request.Pic);
      newshop.SetPkId(new Guid(request.PkId));

      return Task.FromResult(_repo.UpdateShop(newshop));
    }
  }
}