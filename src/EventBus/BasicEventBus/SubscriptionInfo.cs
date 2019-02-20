using System;
using GB_Project.EventBus.BasicEventBus.Abstraction;

namespace GB_Project.EventBus.BasicEventBus
{   
    public class SubscriptionInfo 
    {
      public Type HandlerType { get; private set; }

      public SubscriptionInfo(Type handlerType)
      {
        HandlerType = handlerType;
      }
    }
}