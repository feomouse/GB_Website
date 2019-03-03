using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using System;
using MediatR;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using System.Threading;

namespace GB_Project.Services.MerchantService.MerchantAPI.Controllers
{
  [Route("v1/api/{controller}")]
  [ApiController]
  public class IdentityController : ControllerBase
  {
    private MerchantQuery _query;

    private IMediator _mediator;

    public IdentityController(MerchantQuery query, IMediator mediator)
    {
      _query = query;
      _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> AddAptitude([FromBody] AptitudeViewModel model)
    {
      if(!ModelState.IsValid)
      {
        return StatusCode(400);
      }

      var merchant = _query.GetMerchantBasicByMerchantId(new Guid(model.MerchantId));

      if(merchant == null)
      {
        return StatusCode(401);
      }

      var merchantIdentity = new MerchantIdentity(model.IdentityName, model.IdentityNum, model.IdentityImgF, model.IdentityImgB, model.LicenseImg, 
                           model.LicenseCode, model.LicenseName, model.LicenseOwner, model.AvailableStartTime, 
                           model.AvailableTime, model.Tel);

      var result = await _mediator.Send(new AddIdentityCommand(merchant, merchantIdentity), default(CancellationToken));

      if(result == 0)
      {
        return StatusCode(400);
      }

      return Ok("Add Aptitude Success");
    }
  }
}