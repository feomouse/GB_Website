using System.Text;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace GB_Project.EventBus.EventBusMQ
{
    public class RabbitMqEventBusPublisher : IEventBusPublisher
    {
        private const string GB_EXCHANGE = "GB_Exchange";
        private IRabbitMqPersistConnection _connectFactory;
        private IEventSubscriptionsManager _manager;
        private IModel _channel;

        public RabbitMqEventBusPublisher(IRabbitMqPersistConnection connectFactory, IEventSubscriptionsManager manager)
        {
          _connectFactory = connectFactory;
          _manager = manager;

          if(!_connectFactory.isConnected)
          {
            _connectFactory.TryConnect();
          }

          _channel = _connectFactory.Createchannel();

          _channel.ExchangeDeclare(GB_EXCHANGE, "direct");
        }


        public void Publish(IntergrationEvent @event)
        {
          if(!_connectFactory.isConnected)
          {
            _connectFactory.TryConnect();
          }

          using(var channel = _connectFactory.Createchannel())
          {
            string eventName = @event.GetType().Name;

            string mess = JsonConvert.SerializeObject(@event);

            var body = Encoding.UTF8.GetBytes(mess);

            var properties = channel.CreateBasicProperties();

            properties.DeliveryMode = 2;

            channel.BasicPublish(GB_EXCHANGE, eventName, true, properties , body );
          }
        }
    }
}