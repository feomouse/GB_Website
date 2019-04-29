using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using System.Collections.Generic;

namespace GB_Project.Services.CommentService.CommentAPI.CommentQuery
{
  public class CommentQuery : IQuery
  {
    private ICommentRepository _repo;
    public CommentQuery(ICommentRepository repo)
    {
      _repo = repo;
    }

    public UserComment GetUserCommentByOrderId(string orderId)
    {
      return _repo.GetUserCommentByOrderId(orderId);
    }

    public List<UserComment> GetUserCommentsByProductId(string productId)
    {
      return _repo.GetUserCommentsByProductId(productId);
    }

    public List<UserComment> GetUserCommentsByShopId(string shopId, int page)
    {
      return _repo.GetUserCommentsByShopId(shopId, page);
    }

    public ReplyComment GetReplyCommentByCommentId(string commentId)
    {
      return _repo.GetReplyCommentByCommentId(commentId);
    }

    public int GetUserCommentCountByShopId(string shopId)
    {
      return _repo.GetUserCommentCountByShopId(shopId);
    }
  }
}