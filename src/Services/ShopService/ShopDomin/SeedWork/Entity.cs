using System;
using System.Collections.Generic;
using MediatR;

namespace GB_project.Services.ShopService.ShopDomin.SeedWork
{
  public abstract class Entity
  {
    public Entity () {

    }

    int? _requestedHashCode;
    /* private Guid pkId;

    public Guid PkId { 
      get {
        return pkId;
      }

      set {
        pkId = value;
      }
    } */

    private List<INotification> _dominEvent;

    public IReadOnlyCollection<INotification> DominEvent => _dominEvent?.AsReadOnly();

    public void AddDominEvent(INotification eventItem)
    {
      _dominEvent = _dominEvent ?? new List<INotification>();

      _dominEvent.Add(eventItem);
    }

    public void RemoveDominEvent(INotification eventItem)
    {
      _dominEvent?.Remove(eventItem);
    }

    public void ClearDominEvent()
    {
      _dominEvent?.Clear();
    }

/*     public bool IsTransient()
    {
      return this.PkId == default(Guid);
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.PkId.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is Entity))
      {
        return false;
      }

      if (ReferenceEquals(this, obj))
      {
        return true;
      }

      if (obj.GetType() != obj.GetType())
      {
        return false;
      }

      Entity item = (Entity)obj;

      if (item.IsTransient() || this.IsTransient())
          return false;
      else
          return item.PkId == this.PkId;
    }

    public static bool operator != (Entity left, Entity right) {
      return !(left == right);
    }

    public static bool operator == (Entity left, Entity right) {
      if (Object.Equals(left, null))
      {
        return Object.Equals(right, null) ? true : false;
      }

      else
      {
          return left.Equals(right);
      }
    } */
  }   
}