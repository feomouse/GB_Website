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
      return Task.FromResult(_repo.UpdateShop(request.PkId, request.Name, request.Province, request.City, request.District, request.Location, request.Tel, request.WorkingTime));
    }
  }
}