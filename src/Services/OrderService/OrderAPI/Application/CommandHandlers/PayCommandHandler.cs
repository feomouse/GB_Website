using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using GB_Project.Services.OrderService.OrderAPI.Application.Commands;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using System.Net;

namespace GB_Project.Services.OrderService.OrderAPI.Application.CommandHandlers
{
  public class PayCommandHandler : IRequestHandler<PayCommand, bool>
  {
    private IGBOrderRepository _repo;

    public PayCommandHandler(IGBOrderRepository repo)
    {
      _repo = repo;
    }

    public Task<bool> Handle (PayCommand command, CancellationToken cancellaitonToken)
    {
        var client = new RestClient("http://localhost:50020");

        var request = new RestRequest("/v1/api/pay/order");

        request.AddHeader("TotalCost", command.TotalCost.ToString());
        
        var response = client.Post(request);

        if(response.StatusCode == HttpStatusCode.OK) {
          var result = _repo.SetGBOrderPayed(command.OrderId);

          return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
  }
}