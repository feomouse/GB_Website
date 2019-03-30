using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class SetGBCommandHandler : IRequestHandler<SetGBCommand, int>
  {
    private IShopRepository _repo;

    public SetGBCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<int> Handle(SetGBCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.SetGB(request.ShopId));
    }
  }
}