using System;
using GB_Project.EventBus.BasicEventBus;

namespace GB_Project.Services.UserService.UserAPI.IntergrationEvents.Events
{
  public class UserRegisteredIntergrationEvent : IntergrationEvent
  {
    public UserRegisteredIntergrationEvent(Guid userId) : base(userId, DateTime.Now)
    {

    }
  }
}