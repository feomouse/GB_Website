using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using GB_Project.Services.CommentService.CommentAPI.Application.Commands;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;

namespace GB_Project.Services.CommentService.CommentAPI.Application.CommandsHandle
{
  public class AddReplyCommentCommandHandler : IRequestHandler<AddReplyCommentCommand, int>
  {
    private ICommentRepository _repo;

    public AddReplyCommentCommandHandler(ICommentRepository repo)
    {
      _repo = repo; 
    }
    public Task<int> Handle (AddReplyCommentCommand command, CancellationToken ct)
    {
      DateTime dt = DateTime.Now;
      if(!DateTime.TryParse(command.Date, out dt))
      {
        dt = DateTime.Now;
      }
      ReplyComment RComment = new ReplyComment(command.Reply, dt);

      RComment.SetUserComment(_repo.GetUserCommentByCommentId(command.CommentId));

      _repo.SetCommentIsReply(command.CommentId);
      
      return Task.FromResult(_repo.AddReplyComment(RComment));
    }
  } 
}