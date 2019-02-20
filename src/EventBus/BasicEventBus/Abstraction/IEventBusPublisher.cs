namespace GB_Project.EventBus.BasicEventBus.Abstraction
{
    public interface IEventBusPublisher
    {
      void Publish(IntergrationEvent @event);
    }
}