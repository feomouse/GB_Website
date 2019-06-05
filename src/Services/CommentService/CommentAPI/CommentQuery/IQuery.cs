using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using System.Collections.Generic;

namespace GB_Project.Services.CommentService.CommentAPI.CommentQuery
{
  public interface IQuery
  {
    UserComment GetUserCommentByOrderId(string orderId);

    List<UserComment> GetUserCommentsByProductId(string productId);

    List<UserComment> GetUserCommentsByShopId(string shopId, int page);

    ReplyComment GetReplyCommentByCommentId(string commentId);

    int GetUserCommentCountByShopId(string shopId);

    List<ReplyComment> GetReplyCommentsByCommentIds(List<string> commentIds);

    IList<dynamic> GetCommentNumsAndAverStarsNumByShopIds(List<string> shopIds);

    dynamic GetCommentStarsMoreThree(string shopId, string year);

    dynamic GetCommentStarsLessThree(string shopId, string year);
  }
}