using GB_Project.Services.CommentService.CommentDomin.SeedWork;
using System;

namespace GB_Project.Services.CommentService.CommentDomin.AggregateModel
{
  public class UserComment : Entity
  {
    public string Comment { get; private set; }

    public DateTime Date { get; private set; }

    public int Stars { get; private set; }

    public string Img { get; private set; }

    public Guid OrderId { get; private set; }

    public Guid ProductId { get; private set; }

    public Guid ShopId { get; private set; }

    public bool IsReply { get; private set; }

    public string UserName { get; private set; }

    public UserComment (string comment, DateTime date, int stars, string img, 
                        Guid orderId, Guid productId, Guid shopId, string userName)
    {
      Comment = comment;
      Date = date;
      Stars = stars;
      Img = img;
      OrderId = orderId;
      ProductId = productId;
      ShopId = shopId;
      IsReply = false;
      UserName = userName;
    }

    public void SetIsReply()
    {
      IsReply = true;
    }
  }
}