using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_project.Services.ShopService.ShopAPI.Application.Command;
using GB_project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Controllers
{
  [Route("v1/api/[controller]")]
    public class GBRuleController : ControllerBase
    {
      private IMediator _mediator;
      private IQuery _query;

      public GBRuleController ( IMediator mediator, IQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpGet]
      public ActionResult<GBRule> GetGBRuleByContentAndGBProductId (string content, Guid gbProductId)
      {
        GBRule gbRule = _query.getGBRuleByContentAndGBProductId(content, gbProductId);

        return Ok(gbRule);
      }

      [HttpPost]
      [ProducesResponseType(201)]
      [ProducesResponseType(400)]
      [Route("add")]
      public async Task<ActionResult<GBRule>> AddGBRule ([FromBody] AddGBRuleCommand gbRule )
      {
        int num = await _mediator.Send(gbRule);

        if ( num == 0)
        {
          return BadRequest();
        }

        return CreatedAtAction(nameof(GetGBRuleByContentAndGBProductId), new { content = gbRule.Content, gbProductId = gbRule.GBProductId}, gbRule);
      }
    }
}