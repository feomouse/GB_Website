using MediatR;
using GB_Project.Services.OrderService.OrderAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;

namespace GB_Project.Services.OrderService.OrderAPI.Application.CommandHandlers
{
  public class UseGBOrderCommandHandler : IRequestHandler<UseGBOrderCommand, int>
  {
    private IGBOrderRepository _repo;

    public UseGBOrderCommandHandler(IGBOrderRepository repo)
    {
      _repo = repo;
    }
    public Task<int> Handle (UseGBOrderCommand command, CancellationToken cancellaitonToken)
    {
      return Task.FromResult(_repo.SetGBOrderUsed(command.ShopName, command.OrderCode));
    }
  }
}