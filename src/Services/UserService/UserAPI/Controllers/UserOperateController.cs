using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using MediatR;
using System;
using System.Threading.Tasks;
using GB_Project.Services.UserService.UserAPI.ViewModels;
using GB_Project.Services.UserService.UserAPI.Query;
using GB_Project.Services.UserService.UserAPI.Application.Commands;
using System.Collections.Generic;
using System.IO;
namespace GB_Project.Services.UserService.UserAPI.Controllers
{
  [ApiController]
  [Route("v1/api/user")]
  public class UserOperateController : ControllerBase
  {
    private IUserQuery _query;

    private IMediator _mediator;

    public UserOperateController(IUserQuery query, IMediator mediator)
    {
      _query = query;

      _mediator = mediator;
    }

    [HttpPost]
    [Route("SetImg")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<StatusCodeResult> SetImg([FromBody] SetImgViewModel model)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      var user = _query.GetUserByUserId(model.PkId);

      if(user == null)
      {
        return new StatusCodeResult(401);
      }
    
      var result = await _mediator.Send(new SetImgCommand(user, model.ImgLocation));

      if(result == 0)
      {
        return new StatusCodeResult(400);
      }

      return new StatusCodeResult(200);
    }

    [HttpPost]
    [Route("SetAddress")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<StatusCodeResult> SetUserLocation([FromBody] SetAddressViewModel model)
    {
      if(!ModelState.IsValid)
      {
        return new StatusCodeResult(400);
      }

      User user = _query.GetUserByUserId(model.PkId);

      if(user == null)
      {
        return new StatusCodeResult(401);
      }

      var result = await _mediator.Send(new SetAddressCommand(user, model.Address));

      if (result == 0)
      {
        return new StatusCodeResult(400);
      }

      return new StatusCodeResult(200);
    }

    [HttpPost]
    [Route("uploadImg")]
    public ActionResult UpLoadImg()
    {
      if(Request.Form.Files.Count != 0) 
      {
        var stream = Request.Form.Files[0].OpenReadStream();

        byte[] bytes = new byte[stream.Length]; 

        int readNum = stream.Read(bytes, 0, bytes.Length); 

        System.IO.File.WriteAllBytes("D:\\IMG\\" + Request.Form.Files[0].FileName, bytes);
        
        return Ok(Request.Form.Files[0].FileName);
      }
      else return Ok();
    }
  }
}