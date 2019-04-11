using MediatR;

namespace GB_Project.Services.OrderService.OrderAPI.Application.Commands
{
  public class PayCommand : IRequest<bool>
  {
    public string OrderId { get; set; }

    public int TotalCost { get; set; }

    public PayCommand (string orderId, int totalCost)
    {
      OrderId = orderId;

      TotalCost = totalCost;
    }
  }
}