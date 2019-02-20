using System;
using System.Collections.Generic;
using System.Linq;
using GB_Project.EventBus.BasicEventBus.Abstraction;

namespace GB_Project.EventBus.BasicEventBus
{
    public class InMemorySubscriptionsManager : IEventSubscriptionsManager
    {
      private Dictionary<string, List<SubscriptionInfo>> _handlers = new Dictionary<string, List<SubscriptionInfo>>();

      private List<Type> _eventTypes = new List<Type>();

      public void AddSubscription<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>
      {
        string eventName = GetEventKey<T>();

        if(!_handlers.ContainsKey(eventName))
        {
          _handlers.Add(eventName, new List<SubscriptionInfo>());

          if(!HasSubscriptionForEvent<T>())
          {
            _handlers[eventName].Add(new SubscriptionInfo(typeof(TH)));
          }
        }

        if(!_eventTypes.Contains(typeof(T)))
        {
          _eventTypes.Add(typeof(T));
        }
      }

      public void RemoveSubscription<T, TH> ()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>
      {
        var eventName = GetEventKey<T>();
        SubscriptionInfo handler = null;

        if(!HasSubscriptionForEvent(eventName))
        {
          handler = null;
        }
        else
        {
          handler = _handlers[eventName].Single(b => b.HandlerType == typeof(TH));
        }

        _handlers[eventName].Remove(handler);

        if(!_handlers[eventName].Any())
        {
          _handlers.Remove(eventName);

          var eventTypeRemove = _eventTypes.Single(e => e.Name == eventName);

          if(eventTypeRemove != null)
          {
            _eventTypes.Remove(eventTypeRemove);
          }
        }
      }

      public string GetEventKey<T>() where T : IntergrationEvent
      {
        return typeof(T).Name;
      }

      public bool HasSubscriptionForEvent<T>() where T : IntergrationEvent
      {
        string eventName = GetEventKey<T>();
        return HasSubscriptionForEvent(eventName);
      }

      public bool HasSubscriptionForEvent(string eventName)
      {
        return _handlers[eventName].Count() != 0;
      }

      public List<SubscriptionInfo> GetEventSubscriptionsInfo(string eventName)
      {
        return _handlers[eventName];
      }

      public Type GetEventTypeByName(string eventName)
      {
        return _eventTypes.Single( e => e.Name == eventName);
      }
  }
}