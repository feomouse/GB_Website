using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class DeleteShopTypeCommandHandler : IRequestHandler<DeleteShopTypeCommand, int>
  {
    private IShopRepository _repo;

    public DeleteShopTypeCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<int> Handle(DeleteShopTypeCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.DeleteShopType(request.ShopTypeId));
    }
  }
}