using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GB_Project.EventBus.EventBusMQ
{
    public class RabbitMqEventBusSubscriber : IEventBusSubscriber
    {
      private const string GB_EXCHANGE = "GB_Exchange";

      private IRabbitMqPersistConnection _connectFactory;

      private IEventSubscriptionsManager _manager;

      private IModel _channel;

      private string _queueName;

      private ILifetimeScope _autofac;

      public RabbitMqEventBusSubscriber(string queueName, IRabbitMqPersistConnection connectFactory, IEventSubscriptionsManager manager, ILifetimeScope autofac)
      {
        _connectFactory = connectFactory;

        _manager = manager;

        _queueName = queueName;

        _autofac = autofac;

        if(!_connectFactory.isConnected)
        {
          _connectFactory.TryConnect();
        }

        _channel = _connectFactory.Createchannel();

        _channel.ExchangeDeclare(GB_EXCHANGE, "direct");

        _channel.QueueDeclare(queueName, true, false, false, null);

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (MetadataPropertyHandling, ea) =>
        {
          var eventName = ea.RoutingKey;
          var body = ea.Body;
          var mess = Encoding.UTF8.GetString(body);

          Type eventType = _manager.GetEventTypeByName(eventName);
          var listenEvent = JsonConvert.DeserializeObject(mess, eventType);

          if(_manager.HasSubscriptionForEvent(eventName))
          {
            using(var scope = _autofac.BeginLifetimeScope("GB_Scope_Name"))
            {
              List<SubscriptionInfo> subs = _manager.GetEventSubscriptionsInfo(eventName);

              foreach(SubscriptionInfo subscription in subs)
              {
                var handler = scope.ResolveOptional(subscription.HandlerType);

                if(handler == null) continue;

                typeof(IIntergrationEventHandler<>).MakeGenericType(eventType).GetMethod("Handle").Invoke(handler, new object[]{ listenEvent });
              }
            }
          } 

          _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
      }

      public void Subscribe<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>
      {
        var eventName = _manager.GetEventKey<T>();

        if(!_connectFactory.isConnected)
        {
          _connectFactory.TryConnect();
        }

        using(var channel = _connectFactory.Createchannel())
        {
          _manager.AddSubscription<T, TH>();

          var routingKey = _manager.GetEventKey<T>();

          channel.QueueBind(_queueName, GB_EXCHANGE, routingKey);
        }
      }

      public void UnSubscribe<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>
      {
        var eventName = _manager.GetEventKey<T>();

        if(!_connectFactory.isConnected)
        {
          _connectFactory.TryConnect();
        }

        using(var channel = _connectFactory.Createchannel())
        {
          channel.QueueUnbind(_queueName, GB_EXCHANGE, eventName);

          _manager.RemoveSubscription<T, TH>();
        }
      }
    }
}