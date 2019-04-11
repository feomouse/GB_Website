using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand, int>
  {
    private IShopRepository _repo;

    public DeleteProductTypeCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<int> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.DeleteProductType(request.ProductTypePkId));
    }
  }
}