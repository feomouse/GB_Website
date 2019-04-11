using GB_Project.EventBus.BasicEventBus;

namespace GB_Project.Services.OrderService.OrderAPI.Intergration.Events
{
  public class AddCommentIntergrationEvent : IntergrationEvent
  {
    public string OrderId { get; set; }

    public string CommentId { get; set; }
    
    public AddCommentIntergrationEvent(string orderId, string commentId)
    {
      OrderId = orderId;
      CommentId = commentId;
    }
  }
}