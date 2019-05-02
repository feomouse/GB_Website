using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using GB_Project.Services.OrderService.OrderAPI.Application.Commands;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using System.Net;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.OrderService.OrderAPI.GetQuery;
using GB_Project.Services.OrderService.OrderAPI.Intergration.Events;

namespace GB_Project.Services.OrderService.OrderAPI.Application.CommandHandlers
{
  public class PayCommandHandler : IRequestHandler<PayCommand, bool>
  {
    private IGBOrderRepository _repo;

    private IGBQuery _query;

    private IEventBusPublisher _pub;

    public PayCommandHandler(IGBOrderRepository repo, IGBQuery query, IEventBusPublisher pub)
    {
      _repo = repo;
      _query = query;
      _pub = pub;
    }

    public Task<bool> Handle (PayCommand command, CancellationToken cancellaitonToken)
    {
        var client = new RestClient("http://localhost:50015");

        var request = new RestRequest("/v1/api/pay/order");

        request.AddHeader("TotalCost", command.TotalCost.ToString());
        
        var response = client.Post(request);

        if(response.StatusCode == HttpStatusCode.OK) {
          var result = _repo.SetGBOrderPayed(command.OrderId);

          var order = _query.getGBOrderByOrderId(command.OrderId);
          
          IncreOrderSellIntergrationEvent @event = new IncreOrderSellIntergrationEvent(order.GroupProductName, order.SName, order.TotalCost/order.Number, order.Number);
          _pub.Publish(@event);

          return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
  }
}