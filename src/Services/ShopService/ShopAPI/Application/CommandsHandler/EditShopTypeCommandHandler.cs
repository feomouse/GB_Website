using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class EditShopTypeCommandHandler : IRequestHandler<EditShopTypeCommand, ShopType>
  {
    private IShopRepository _repo;

    public EditShopTypeCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<ShopType> Handle(EditShopTypeCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.EditShopType(new ShopType(new Guid(request.PkId), request.Name, request.Img)));
    }
  }
}