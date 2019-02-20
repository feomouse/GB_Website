using System;

namespace GB_Project.EventBus.BasicEventBus
{
    public class IntergrationEvent
    {
      public Guid Id { get; set; }

      public DateTime TimeStamp { get; set; }

      public IntergrationEvent ()
      {
        Id = Guid.NewGuid();
        TimeStamp = DateTime.UtcNow;
      }

      public IntergrationEvent (Guid id, DateTime timeStamp)
      {
        Id = id;
        TimeStamp = timeStamp;
      }
    }
}