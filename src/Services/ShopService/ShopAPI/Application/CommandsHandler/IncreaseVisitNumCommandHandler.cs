using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class IncreaseVisitNumCommandHandler : IRequestHandler<IncreaseVisitNumCommand, int>
  {
    private IShopRepository _repo;

    public IncreaseVisitNumCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<int> Handle(IncreaseVisitNumCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.IncreaseVisitNum(request.ShopId, request.Year, request.Month));
    }
  }
}