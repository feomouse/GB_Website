using System;

namespace GB_Project.Services.CommentService.CommentDomin.SeedWork
{
  public class Entity
  {
    public Guid PkId { get; private set; }

    public Entity()
    {
      PkId = Guid.NewGuid();
    }
    public Entity(Guid pkId)
    {
      PkId = pkId;
    }
  }
}