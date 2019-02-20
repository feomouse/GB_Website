using RabbitMQ.Client;

namespace GB_Project.EventBus.EventBusMQ
{
    public class DefaultRabbitMqPersistConnection : IRabbitMqPersistConnection
    {
      private ConnectionFactory _factory;
      private IConnection _connection;

      private IModel _channel;

      public DefaultRabbitMqPersistConnection(ConnectionFactory factory)
      {
        _factory = factory;
      }

      public bool isConnected
      {
        get 
        {
          return _connection != null && _connection.IsOpen; 
        }
      }

      public void TryConnect ()
      {
        _connection = _factory.CreateConnection();
      }

      public IModel Createchannel()
      {
        if (isConnected)
        {
          return _connection.CreateModel();
        }

        else return null;
      }
  }
}