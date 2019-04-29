using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using System.Threading.Tasks;
using GB_Project.Services.IdentityService.IdentityAPI.ViewModels;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Threading;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using System;
using GB_Project.Services.IdentityService.IdentityAPI.IntergrationEvents.Events;
using MediatR;
using GB_Project.Services.IdentityService.IdentityAPI.Query;
using System.Collections.Generic;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;

namespace GB_Project.Services.IdentityService.IdentityAPI.Controllers
{
  [Route("v1/api/identity")]
  public class InfoController : ControllerBase
  {
    private IUserQuery _userQuery;
    
    private IEventBusPublisher _eventBusPublisher;

    public InfoController(IUserQuery userQuery, IEventBusPublisher eventBusPublisher)
    {
      _userQuery = userQuery;

      _eventBusPublisher = eventBusPublisher;
    }

    [HttpGet]
    [Route("merchantInfo")]
    public MerchantInfoViewModel GetMerchantInfo([FromHeader] string merchantId) 
    {
      var user = _userQuery.FindUserById(merchantId, "MERCHANT");

      return new MerchantInfoViewModel() {Name = user.UserName};
    }

    [HttpPost]
    [Route("merchantInfoList")]
    public ActionResult GetMerchantInfoList([FromBody] List<GetMerchantNameListCommand> merchantIdList)
    {
      List<string> userNameArr = new List<string>();

      foreach(var i in merchantIdList)
      {
        userNameArr.Add(_userQuery.FindUserById(i.Id, "MERCHANT").UserName);
      }

      return Ok(userNameArr);
    }
  }    
}