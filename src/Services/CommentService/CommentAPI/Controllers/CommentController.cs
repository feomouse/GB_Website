using MediatR;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.CommentService.CommentAPI.Application.Commands;
using GB_Project.Services.CommentService.CommentAPI.CommentQuery;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using System.Collections.Generic;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.Services.CommentService.CommentAPI.Intergration.Events;
using System;

namespace GB_Project.Services.CommentService.CommentAPI.Controller
{
  [Route("/v1/api/comment")]
  [ApiController]
  public class CommentController : ControllerBase
  {
    private IMediator _mediator;
    private IQuery _query;
    private IEventBusPublisher _pub;

    public CommentController(IMediator mediator, IQuery query, IEventBusPublisher pub)
    {
      _mediator = mediator;
      _query = query;
      _pub = pub;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Route("addUserComment")]
    public ActionResult AddUserComment([FromBody] AddUserCommentCommand command)
    {
      int result = _mediator.Send(command).GetAwaiter().GetResult();
          
      if(result == 0) return BadRequest();

      var comment = _query.GetUserCommentByOrderId(command.OrderId);
      if(comment == null) return BadRequest();

      _pub.Publish(new AddCommentIntergrationEvent(command.OrderId, comment.PkId.ToString()));

      return StatusCode(201);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("getUserCommentByOrderId")]
    public ActionResult GetUserCommentByOId([FromHeader] string orderId)
    {
      UserComment comment = _query.GetUserCommentByOrderId(orderId);

      if(comment == null) return BadRequest();

      return Ok(comment);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("getUserCommentsByProductId")]
    public ActionResult GetUserCommentByPId([FromHeader] string productId)
    {
      List<UserComment> comments = _query.GetUserCommentsByProductId(productId);

      if(comments == null) return BadRequest();

      return Ok(comments);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("getUserCommentsByShopId")]
    public ActionResult GetUserCommentsByShopId([FromHeader] string shopId, [FromQuery]int page)
    {
      List<UserComment> comments = _query.GetUserCommentsByShopId(shopId, page);

      if(comments == null) return BadRequest();

      return Ok(comments);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Route("addReplyComment")]
    public ActionResult AddReplyComment([FromBody] AddReplyCommentCommand command)
    {
      var result = _mediator.Send(command).GetAwaiter().GetResult();

      if(result == 0) return BadRequest();

      return StatusCode(201);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("getReplyComment")]
    public ActionResult GetReplyCommentByCommentId([FromHeader] string commentId)
    {
      var reply = _query.GetReplyCommentByCommentId(commentId);
 
      if(reply == null) return BadRequest();

      else return Ok(reply);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("getUserCommentCount")]
    public ActionResult GetUserCommentCountByShopId([FromHeader] string shopId)
    {
      return Ok(_query.GetUserCommentCountByShopId(shopId));
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("getReplyComments")]
    public ActionResult GetReplyComments([FromBody] List<string> commentIds)
    {
      return Ok(_query.GetReplyCommentsByCommentIds(commentIds));
    }

    [HttpPost]
    [Route("getCommentsNumAndAverStarsNumByShopIds")]
    public ActionResult GetCommentsNumAndAverStarsNumByShopIds([FromBody] List<string> shopIds)
    {
      return Ok(_query.GetCommentNumsAndAverStarsNumByShopIds(shopIds));
    }

    [HttpPost]
    [Route("getCommentStarsMoreThree")]
    public ActionResult GetCommentStarsMoreThree([FromHeader]string shopId, [FromQuery]string year)
    {
      return Ok(_query.GetCommentStarsMoreThree(shopId, year));
    }

    [HttpPost]
    [Route("getCommentStarsLessThree")]
    public ActionResult GetCommentStarsLessThree([FromHeader]string shopId, [FromQuery]string year)
    {
      return Ok(_query.GetCommentStarsLessThree(shopId, year));
    }
  }
}