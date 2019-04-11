using MediatR;
using System;

namespace GB_Project.Services.CommentService.CommentAPI.Application.Commands
{
  public class AddUserCommentCommand : IRequest<int>
  {
    public string Comment { get; set; }

    public DateTime Date { get; set; }

    public int Stars { get; set; }

    public string Img { get; set; }

    public string OrderId { get; set; }

    public string ProductId { get; set; }

    public string ShopId { get; set; }

    public string UserName { get; set; }

    public AddUserCommentCommand(string comment, DateTime date, int stars,
                                 string img, string orderId, string productId, string shopId, string userName)
    {
      Comment = comment;
      Date = date;
      Stars = stars;
      Img = img;
      OrderId = orderId;
      ProductId = productId;
      ShopId = shopId;
      UserName = userName;
    }
  }
}