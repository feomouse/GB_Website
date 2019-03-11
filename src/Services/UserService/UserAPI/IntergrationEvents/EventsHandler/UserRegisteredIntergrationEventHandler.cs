using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.UserService.UserAPI.IntergrationEvents.Events;
using System.Threading.Tasks;

namespace GB_Project.Services.UserService.UserAPI.IntergrationEvents.EventsHandler
{
  public class UserRegisteredIntergrationEventHandler : IIntergrationEventHandler<UserRegisteredIntergrationEvent>
  {
    private IUserRepository _repo;

    public UserRegisteredIntergrationEventHandler(IUserRepository repo)
    {
      _repo = repo;
    }
    public Task Handle (UserRegisteredIntergrationEvent @event)
    {
      var user = new User(@event.Id, @event.Email);
      return Task.FromResult(_repo.CreateUser(user));
    }
  }
}