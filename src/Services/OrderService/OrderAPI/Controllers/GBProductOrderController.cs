using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GB_Project.Services.OrderService.OrderAPI.Application.Commands;
using GB_Project.Services.OrderService.OrderAPI.GetQuery;
using System.Text;
using System.IO;

namespace OrderAPI.Controllers
{
    [Route("/v1/api/order")]
    [ApiController]
    public class GBProductOrderController : ControllerBase
    {
      private IMediator _mediator;
      private IGBQuery _query;
      
      public GBProductOrderController(IMediator mediator, IGBQuery query) 
      {
          _mediator = mediator;
          _query = query;
      }
      
      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("add")]
      public ActionResult AddGBProductOrder([FromBody] AddGBOrderCommand command)
      {
        int result = _mediator.Send(command).GetAwaiter().GetResult();

        if(result == 0) return BadRequest();

        return StatusCode(201);
      }

      [HttpGet]
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [Route("getOrdersList")]
      public ActionResult GetGBProductOrdersList([FromHeader] string userId)
      {
        var orders = _query.getGBProductListByUserId(userId);

        if(orders == null) return BadRequest();

        return Ok(orders);
      }

      [HttpPost]
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [Route("pay")]
      public ActionResult Pay([FromBody]PayCommand command)
      {
        bool result = _mediator.Send(command).GetAwaiter().GetResult();
        
        if(result == false) return BadRequest();
        
        return Ok();
      }

      [HttpPost]
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [Route("SetUsed")]
      public ActionResult SetOrderUsed([FromBody] UseGBOrderCommand command)
      {
        int result = _mediator.Send(command).GetAwaiter().GetResult();

        if(result == 0) return BadRequest();

        return Ok();
      }
    }
}
