using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using System.Threading.Tasks;
using GB_Project.Services.IdentityService.IdentityAPI.ViewModels;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Threading;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using System;
using GB_Project.Services.IdentityService.IdentityAPI.IntergrationEvents.Events;

namespace GB_Project.Services.IdentityService.IdentityAPI.Controllers
{
  [Route("v1/api/[controller]")]
  public class RegisterController : ControllerBase
  {
    private AppUserStore _userStore;

    private IEventBusPublisher _eventBusPublisher;

    public RegisterController(AppUserStore userStore, IEventBusPublisher eventBusPublisher)
    {
      _userStore = userStore;

      _eventBusPublisher = eventBusPublisher;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest("Invail state");
      }

      if(_userStore.FindByEmailAsync(model.Email).GetAwaiter().GetResult() != null)
      {
        return BadRequest("Already exist");
      }

      if(model.Password != model.ConfirmedPassword)
      {
        return BadRequest("two different password");
      }

      var user = new AppUser()
      {
        UserName = model.Email,
        Email = model.Email,
        EmailConfirmed = true
      };
  
      var result = _userStore.CreateWithPasswordAsync(user, model.Password).GetAwaiter().GetResult();

      if(!result.Succeeded)
      {
        return BadRequest("Create Error");
      }

      await _userStore.AddToRoleAsync(user, model.Role);

      string id = await _userStore.GetUserIdAsync(user);

      if (id != null)
      {
        Guid gid = Guid.Parse(id);
        var @event = new MerchantRegisteredIntergrationEvent(gid);

        _eventBusPublisher.Publish(@event);

        return Ok();
      }

      else return BadRequest("No send intergrationevent");
    }
  }    
}