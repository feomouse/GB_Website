using System.Collections.Generic;

namespace GB_Project.Services.CommentService.CommentDomin.AggregateModel
{
  public interface ICommentRepository
  {
    int AddUserComment(UserComment comment);

    UserComment GetUserCommentByOrderId(string orderId);

    List<UserComment> GetUserCommentsByProductId(string productId);

    List<UserComment> GetUserCommentsByShopId(string shopId, int page);

    UserComment GetUserCommentByCommentId(string commentId);

    ReplyComment GetReplyCommentByCommentId(string commentId);

    int AddReplyComment(ReplyComment comment);

    bool SetCommentIsReply(string commentId);

    int GetUserCommentCountByShopId(string shopId);
  }
}