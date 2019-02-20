namespace GB_Project.EventBus.BasicEventBus.Abstraction
{
    public interface IEventBusSubscriber
    {
        void Subscribe<T, TH>()
        where T : IntergrationEvent
        where TH : IIntergrationEventHandler<T>;

        void UnSubscribe<T, TH>()
        where T : IntergrationEvent
        where TH : IIntergrationEventHandler<T>;
    }
}