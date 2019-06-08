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

    public List<UserComment> GetUserCommentsByShopId(string shopId, int page)
    {
      if((page-1) < 0) return null;
      return _context.UserComments.Where(b => b.ShopId.ToString() == shopId).Skip((page-1)*3).Take(3).OrderByDescending(b => b.Date).ToList();
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

    public int GetUserCommentCountByShopId(string shopId)
    {
      return _context.UserComments.Where(u => u.ShopId.ToString() == shopId).ToList().Count;
    }

    public List<ReplyComment> GetReplyCommentsByCommentIds(List<string> commentIds)
    {
      List<ReplyComment> rcomments = new List<ReplyComment>();

      foreach(string i in commentIds)
      {
        rcomments.Add(_context.ReplyComments.Where(r => r.CommentId.ToString() == i).FirstOrDefault());
      }
      return rcomments;
    }

    public IList<dynamic> GetCommentNumsAndAverStarsNumByShopIds(List<string> shopIds)
    {
      var result = new List<dynamic>();

      foreach(var i in shopIds)
      {
        if(_context.UserComments.Count(uc => uc.ShopId.ToString() == i) != 0) {
          result.Add(new {commentsNum= _context.UserComments.Count(uc => uc.ShopId.ToString() == i),
                          averStarsNum= _context.UserComments.Where(uc => uc.ShopId.ToString() == i).Select(uc => uc.Stars).Average()});
        }
        else {
          result.Add(new {commentsNum= _context.UserComments.Count(uc => uc.ShopId.ToString() == i),
                          averStarsNum= 0});
        }
      }

      return result;
    }

    public dynamic GetCommentStarsMoreThree(string shopId, string year)
    {
      return _context.UserComments.Where(uc => (uc.ShopId.ToString() == shopId && uc.Date.Year.ToString() == year && uc.Stars >= 3))
                           .Select(uc => new {month=uc.Date.Month}).ToList();
    }

    public dynamic GetCommentStarsLessThree(string shopId, string year)
    {
      return _context.UserComments.Where(uc => (uc.ShopId.ToString() == shopId && uc.Date.Year.ToString() == year && uc.Stars < 3))
                           .Select(uc => new {month=uc.Date.Month}).ToList();
    }
  }
}