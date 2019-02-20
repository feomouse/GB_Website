using RabbitMQ.Client;

namespace GB_Project.EventBus.EventBusMQ
{
    public interface IRabbitMqPersistConnection
    {
      bool isConnected { get; }
      void TryConnect ();

      IModel Createchannel();
    }
}