using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class DeleteGBProductCommandHandler : IRequestHandler<DeleteGBProductCommand, int>
  {
    private IShopRepository _repo;

    public DeleteGBProductCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<int> Handle(DeleteGBProductCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.DeleteGBProduct(request.GBProductName));
    }
  }
}