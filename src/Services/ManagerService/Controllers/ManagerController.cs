using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ManagerService.Services;
using GB_Project.Services.ManagerService.Querys;
using GB_Project.Services.ManagerService.Application.Commands;
using MediatR;

namespace GB_Project.Services.ManagerService.Controllers
{
    [Route("v1/api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerRepository _repo;
        private IManagerQuery _query;

        private IMediator _mediator;
        public ManagerController(IManagerRepository repo, IManagerQuery query, IMediator mediator)
        {
            _repo = repo;
            _query = query;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ViolateUsers")]
        public ActionResult GetViolateUsers([FromQuery]int page)
        {
            return Ok(_query.GetViolateUsers(page));
        }

        [HttpPost]
        [Route("SetViolateUser")]
        public ActionResult SetViolateUser([FromBody]SetViolateUserCommand command)
        {
          if(_mediator.Send(command).GetAwaiter().GetResult()) return StatusCode(201);

          else return BadRequest(); 
        }

        [HttpGet]
        [Route("IfInVioList")]
        public ActionResult IfInVioList([FromQuery]string userName) 
        {
            if(_query.GetViolateUserByUserName(userName) == null) return Ok(false);

            else return Ok(true);
        }

        [HttpGet]
        [Route("GetVioNum")]
        public ActionResult GetVioNum()
        {
            return Ok(_query.GetVioNum());
        }
    }
}
