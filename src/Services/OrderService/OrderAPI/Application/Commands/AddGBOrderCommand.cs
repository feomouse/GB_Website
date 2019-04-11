using MediatR;

namespace GB_Project.Services.OrderService.OrderAPI.Application.Commands
{
    public class AddGBOrderCommand : IRequest<int>
    {
      public string GroupProductName { get; private set; }

      public int Number { get; private set; }

      public int TotalCost { get; private set; }

      public bool IsPayed { get; private set; }

      public string Evaluate { get; private set; }
    
      public bool IsUsed { get; private set; }

      public string OrderCode { get; private set; }

      public int PayWay { get; private set; }

      public string CpkId { get; private set; }

      public string SName { get; private set; }

      public string Time { get; private set; }

      public string Img { get; private set; }

      public AddGBOrderCommand(string groupProductName, int number, int totalCost, bool isPayed, string evaluate, bool isUsed,
                              string orderCode, int payWay, string cpkId, string sName, string time, string img)
      {
        GroupProductName = groupProductName;
        Number = number;
        TotalCost = totalCost;
        IsPayed = isPayed;
        Evaluate = evaluate;
        IsUsed = isUsed;
        OrderCode = orderCode;
        PayWay = payWay;
        CpkId = cpkId;
        SName = sName;
        Time = time;
        Img = img;
      }
    }
}