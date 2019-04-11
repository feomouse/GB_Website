namespace GB_Project.Services.PaymentService.Application.Commands
{
  public class PaymentCommand
  {
    public int TotalCost { get; set; }

    public PaymentCommand(int totalCost)
    {
      TotalCost = totalCost;
    }
  }
}