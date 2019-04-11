using MediatR;
using GB_Project.Services.OrderService.OrderAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;

namespace GB_Project.Services.OrderService.OrderAPI.Application.CommandHandlers
{
    public class AddGBOrderCommandHandler : IRequestHandler<AddGBOrderCommand, int>
    {
      private IGBOrderRepository _repo;

      public AddGBOrderCommandHandler(IGBOrderRepository repo)
      {
        _repo = repo;
      }

      public Task<int> Handle(AddGBOrderCommand command, CancellationToken cancellaitonToken)
      {
        var order = new GroupBuyingOrder(command.GroupProductName, command.Number, command.TotalCost, command.IsPayed, 
                             "", command.IsUsed, Guid.NewGuid(), command.PayWay,
                             new Guid(command.CpkId), command.SName, DateTime.Parse(command.Time), command.Img);
        return Task.FromResult(_repo.AddGBOrder(order));
      }
    }
}