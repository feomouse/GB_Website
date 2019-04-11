using MediatR;
using System;

namespace GB_Project.Services.CommentService.CommentAPI.Application.Commands
{
  public class AddReplyCommentCommand : IRequest<int>
  {
    public string CommentId { get; set; }

    public string Reply { get; set; }

    public DateTime Date { get; set; }

    public AddReplyCommentCommand(string commentId, string reply, DateTime date)
    {
      CommentId = commentId;
      Reply = reply;
      Date = date;
    }
  }
}