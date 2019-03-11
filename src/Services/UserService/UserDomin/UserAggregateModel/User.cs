using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserDomin.SeedWork;
using System;

namespace GB_Project.Services.UserService.UserDomin.UserAggregateModel
{
  public class User : Entity, IAggregateRoot
  {
    public Guid PkId { get; private set; }

    public string LookingImg { get; private set; }

    public string Address { get; private set; }

    public string Email { get; private set; }

    public string UserName { get; private set; }

    public User(Guid pkId)
    {
      PkId = pkId;
    }

    public User(Guid pkId, string email)
    {
      PkId = pkId;
      Email = email;
    }

    public void SetAddress (string address)
    {
      Address = address;
    }

    public void SetLookingImg (string img)
    {
      LookingImg = img;
    }

    public void SetUserName (string name)
    {
      UserName = name;
    }
  }
}