using System;
using GB_Project.Services.OrderService.OrderDomin.SeedWork;

namespace GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate
{
    public class GroupBuyingOrder : IAggregateRoot
    {
      public Guid PkId { get; private set; }

      public string GroupProductName { get; private set; }

      public int Number { get; private set; }

      public int TotalCost { get; private set; }

      public bool IsPayed { get; private set; }

      public string Evaluate { get; private set; }
    
      public bool IsUsed { get; private set; }

      public Guid OrderCode { get; private set; }

      public int PayWay { get; private set; }

      public Guid CpkId { get; private set; }

      public Guid SpkId { get; private set; }

      public string SName { get; private set; }

      public DateTime Time { get; private set; }

      public string Img { get; private set; }

      public GroupBuyingOrder(string groupProductName, int number, int totalCost, bool isPayed, string evaluate, bool isUsed,
                              Guid orderCode, int payWay, Guid cpkId, Guid spkId, string sName, DateTime time, string img)
      {
        PkId = Guid.NewGuid();
        GroupProductName = groupProductName;
        Number = number;
        TotalCost = totalCost;
        IsPayed = isPayed;
        Evaluate = evaluate;
        IsUsed = isUsed;
        OrderCode = orderCode;
        PayWay = payWay;
        CpkId = cpkId;
        SpkId = spkId;
        SName = sName;
        Time = time;
        Img = img;
      }

      public void SetIsPayed()
      {
        IsPayed = true;
      }

      public void SetIsUsed()
      {
        IsUsed = true;
      }

      public void SetCommentId(string commentId)
      {
        Evaluate = commentId;
      }
    }
}