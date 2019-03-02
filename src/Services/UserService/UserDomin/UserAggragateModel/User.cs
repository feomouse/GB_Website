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

    public User(string lookingImg, string address)
    {
      PkId = Guid.NewGuid();
      LookingImg = lookingImg;
      Address = address;
    }
  }
}