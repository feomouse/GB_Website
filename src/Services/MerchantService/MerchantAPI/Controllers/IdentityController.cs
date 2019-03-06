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
  [Route("v1/api/merchant")]
  [ApiController]
  public class IdentityController : ControllerBase
  {
    private IMerchantQuery _query;

    private IMediator _mediator;

    public IdentityController(IMerchantQuery query, IMediator mediator)
    {
      _query = query;
      _mediator = mediator;
    }

    [HttpPost]
    [Route("AddIdentity")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public StatusCodeResult AddAptitude([FromBody] AptitudeViewModel model)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      var merchant = _query.GetMerchantBasicByMerchantId(model.MerchantId);

      if(merchant == null)
      {
        return new StatusCodeResult(401);
      }

      var merchantIdentity = new MerchantIdentity(model.IdentityName, model.IdentityNum, model.IdentityImgF, model.IdentityImgB, model.LicenseImg, 
                           model.LicenseCode, model.LicenseName, model.LicenseOwner, model.AvailableStartTime, 
                           model.AvailableTime, model.Tel);

      var resultCreate = _mediator.Send(new AddIdentityCommand(merchant, merchantIdentity), default(CancellationToken));

      if(resultCreate.Result == null)
      {
        return new StatusCodeResult(400);
      }

      var resultAttach = _mediator.Send(new AttachIdentityIdToMerchantCommand(merchant, merchantIdentity),
                                              default(CancellationToken));

      if(resultAttach.Result == 0)
      {
        return new StatusCodeResult(400);
      }

      return new StatusCodeResult(200);
    }
  }
}