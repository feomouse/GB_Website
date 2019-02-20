namespace GB_Project.EventBus.BasicEventBus.Abstraction
{
    public interface IEventBus
    {
      void Publish(IntergrationEvent @event);

      void Subscribe<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>;

      void Unsubscribe<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>;
    }
}