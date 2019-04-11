using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.EventBus.BasicEventBus;
using System.Threading.Tasks;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using GB_Project.Services.OrderService.OrderAPI.Intergration.Events;

namespace GB_Project.Services.OrderService.OrderAPI.Intergration.EventsHandler
{
  public class AddCommentIntergrationEventHandler : IIntergrationEventHandler<AddCommentIntergrationEvent>
  {
    private IGBOrderRepository _repo;

    public AddCommentIntergrationEventHandler(IGBOrderRepository repo)
    {
      _repo = repo;
    }
    public Task Handle(AddCommentIntergrationEvent @eventName)
    {
      return Task.FromResult(_repo.SetGBOrderComment(@eventName.OrderId, @eventName.CommentId));
    }
  }
}