using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using System.Collections.Generic;

namespace GB_Project.Services.CommentService.CommentAPI.CommentQuery
{
  public interface IQuery
  {
    UserComment GetUserCommentByOrderId(string orderId);

    List<UserComment> GetUserCommentsByProductId(string productId);

    List<UserComment> GetUserCommentsByShopId(string shopId);
  }
}