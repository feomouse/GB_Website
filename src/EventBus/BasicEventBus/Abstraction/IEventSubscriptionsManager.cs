using System;
using System.Collections.Generic;

namespace GB_Project.EventBus.BasicEventBus.Abstraction
{
  public interface IEventSubscriptionsManager
  {
      void AddSubscription<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>;

      void RemoveSubscription<T, TH>()
      where T : IntergrationEvent
      where TH : IIntergrationEventHandler<T>;

      string GetEventKey<T>() where T : IntergrationEvent;

      bool HasSubscriptionForEvent<T>() where T : IntergrationEvent;
      
      bool HasSubscriptionForEvent(string eventName);

      List<SubscriptionInfo> GetEventSubscriptionsInfo(string eventName);

      Type GetEventTypeByName(string eventName);
  }   
}