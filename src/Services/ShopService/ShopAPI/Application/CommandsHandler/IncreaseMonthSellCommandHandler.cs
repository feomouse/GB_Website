using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
  public class IncreaseMonthSellCommandHandler : IRequestHandler<IncreaseMonthSellCommand, int>
  {
    private IShopRepository _repo;

    public IncreaseMonthSellCommandHandler(IShopRepository repository)
    {
      _repo = repository;
    }
    public Task<int> Handle(IncreaseMonthSellCommand request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_repo.IncreaseMonthSell(request.ShopId, request.Year, request.Month, request.Num));
    }
  }
}