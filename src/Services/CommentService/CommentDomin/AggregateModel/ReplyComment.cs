using GB_Project.Services.CommentService.CommentDomin.SeedWork;
using System;

namespace GB_Project.Services.CommentService.CommentDomin.AggregateModel
{
  public class ReplyComment : Entity
  {
    public Guid CommentId { get; private set; }

    public UserComment Comment { get; private set; }

    public string Reply { get; private set; }

    public DateTime Date { get; private set; }

    public ReplyComment (string reply, DateTime date)
    {
      Reply = reply;
      Date = date;
    }

    public void SetUserComment(UserComment comment)
    {
      Comment = comment;
    }
  }
}