using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using GB_Project.Services.CommentService.CommentInfrastructrue.Context;
using System.Linq;
using System.Collections.Generic;

namespace GB_Project.Services.CommentService.CommentInfrastructrue.Repository
{
  public class CommentRepository : ICommentRepository
  {
    private CommentContext _context; 
    public CommentRepository(CommentContext context)
    {
      _context = context;
    }

    public int AddUserComment(UserComment comment)
    {
      _context.UserComments.Add(comment);

      return _context.SaveChanges();
    }

    public UserComment GetUserCommentByOrderId(string orderId)
    {
      return _context.UserComments.Where(b => b.OrderId.ToString() == orderId).FirstOrDefault();
    }

    public List<UserComment> GetUserCommentsByProductId(string productId)
    {
      return _context.UserComments.Where(b => b.ProductId.ToString() == productId).ToList();
    }

    public List<UserComment> GetUserCommentsByShopId(string shopId)
    {
      return _context.UserComments.Where(b => b.ShopId.ToString() == shopId).OrderByDescending(b => b.Date).ToList();
    }

    public UserComment GetUserCommentByCommentId(string commentId)
    {
      return _context.UserComments.Where(b => b.PkId.ToString() == commentId).FirstOrDefault();
    }

    public int AddReplyComment(ReplyComment comment)
    {
      _context.ReplyComments.Add(comment);

      return _context.SaveChanges(); 
    }

    public ReplyComment GetReplyCommentByCommentId(string commentId)
    {
      return _context.ReplyComments.Where(b => b.CommentId.ToString() == commentId).FirstOrDefault();
    }

    public bool SetCommentIsReply(string commentId)
    {
      _context.UserComments.Where(u => u.PkId.ToString() == commentId).FirstOrDefault().SetIsReply();

      return (_context.SaveChanges() != 0);
    }
  }
}