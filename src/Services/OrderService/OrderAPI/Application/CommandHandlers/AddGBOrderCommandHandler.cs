using MediatR;
using GB_Project.Services.OrderService.OrderAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using System.Globalization;

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
        DateTime dt = DateTime.Now;
        if(!DateTime.TryParse(command.Time, out dt))
        {
          dt = DateTime.Now;
        }
        var order = new GroupBuyingOrder(command.GroupProductName, command.Number, command.TotalCost, command.IsPayed, 
                             "", command.IsUsed, Guid.NewGuid(), command.PayWay,
                             new Guid(command.CpkId), new Guid(command.SpkId), command.SName, dt, command.Img);
        return Task.FromResult(_repo.AddGBOrder(order));
      }
    }
}