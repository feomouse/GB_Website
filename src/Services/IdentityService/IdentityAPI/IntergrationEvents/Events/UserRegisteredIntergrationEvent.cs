using System;
using GB_Project.EventBus.BasicEventBus;

namespace GB_Project.Services.IdentityService.IdentityAPI.IntergrationEvents.Events
{
  public class UserRegisteredIntergrationEvent : IntergrationEvent
  {
    public string Email { get; set; } 
    public UserRegisteredIntergrationEvent(Guid userId, string email) : base(userId, DateTime.Now)
    {
       Email = email;
    }
  }
}