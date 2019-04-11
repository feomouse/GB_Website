using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using GB_Project.Services.CommentService.CommentAPI.Application.Commands;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;

namespace GB_Project.Services.CommentService.CommentAPI.Application.CommandsHandle
{
  public class AddUserCommentCommandHandler : IRequestHandler<AddUserCommentCommand ,int>
  {
    public ICommentRepository _repo;

    public AddUserCommentCommandHandler(ICommentRepository repo)
    {
      _repo = repo;
    }
    public Task<int> Handle(AddUserCommentCommand command, CancellationToken ct)
    {
      return Task.FromResult(_repo.AddUserComment(new UserComment(command.Comment, command.Date, 
                           command.Stars, command.Img, new Guid(command.OrderId), 
                           new Guid(command.ProductId), new Guid(command.ShopId), command.UserName)));
    }
  }
}