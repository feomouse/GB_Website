using System.Threading.Tasks;

namespace GB_Project.EventBus.BasicEventBus.Abstraction
{
  public interface IIntergrationEventHandler<T> where T : IntergrationEvent
  {
    Task Handle(T @eventName);
  }   
}