using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GB_Project.Services.IdentityService.IdentityAPI.ViewModels;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Repository;
using System.Threading;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
// using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;
using GB_Project.Services.IdentityService.IdentityAPI.Query;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityAPI.Controllers
{
    [Route("v1/api/identity")]
    public class SignInController : ControllerBase
    {
      private readonly MyIdentityDbContext _db;

      private IMediator _mediator;

      private IUserQuery _query;

      public SignInController( IMediator mediator, IUserQuery query)
      {
        _mediator = mediator;
        _query = query;
      }

      [HttpPost]
      [Route("login")]
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [ProducesResponseType(401)]
      [ProducesResponseType(403)]
      public async Task<ActionResult> SignIn([FromBody]SignInCommand model)
      {
        if(!ModelState.IsValid)
        {
          return StatusCode(400);
        }

        AppUser user = null;
        if(model.Email == "")
        {
          user = _query.FindUserByName(model.PhoneNumber);
        }else if(model.PhoneNumber == "")
        {
          user = _query.FindUserByName(model.Email);
        }

        if(user == null)
        {
          return StatusCode(401);
        }

        var signInResult = _mediator.Send(model).GetAwaiter().GetResult();

        if(!signInResult)
        {
          return StatusCode(403);
        }

        var token = await GenerateToken(user);
        
        var signin = new SignInViewModel(token, user.Id);
        return Ok(signin);
      }

      [HttpPost]
      [Route("refresh")]
      [ProducesResponseType(400)]
      [ProducesResponseType(200)]
      public async Task<IActionResult> Refresh ([FromBody]RefreshTokenViewModel refresh_token)
      {
        if(!ModelState.IsValid)
        {
          return BadRequest("Invalid state");
        }

        var user = _query.GetAppUserByRefreshToken(refresh_token.RefreshToken);

        var userCopy = _query.FindUserByName(user.UserName);

        if(user == null)
        {
          return BadRequest("Invail refresh token");
        }

        var token = await GenerateToken(userCopy);

        return Ok(token);
      }

      private async Task<TokenViewModel> GenerateToken(AppUser user)
      {
        var expireTime = DateTime.Now.AddMinutes(Convert.ToDouble(10));
        var notBefore = DateTime.Now;

        var claims = new List<Claim>(){
          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(ClaimTypes.Name, user.UserName),
          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.Exp, expireTime.ToString()),
          new Claim(JwtRegisteredClaimNames.Nbf, notBefore.ToString())
        };

        var refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        string jwtKeyString = "Group_Buy_Website_Token_Key";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKeyString));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        IList<string> roles = _query.GetRolesAsync(user);

        foreach( string role in roles)
        {
          claims.Add(new Claim(ClaimTypes.Role, role));
        }

        user.SetRefreshToken(refresh_token);

        await _mediator.Send(new UpdateUserCommand(user));

        var token = new JwtSecurityToken("https://localhost:5000", "GB",
                                        claims, notBefore, expireTime, cred);

        return new TokenViewModel(){ access_token = new JwtSecurityTokenHandler().WriteToken(token), refresh_token = refresh_token};
      }
    }
}
