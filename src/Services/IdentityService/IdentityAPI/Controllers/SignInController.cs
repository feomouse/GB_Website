using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GB_project.Services.IdentityService.IdentityAPI.ViewModels;
using GB_project.Services.IdentityService.IdentityDomin.AggregatesModel;
using GB_project.Services.IdentityService.IdentityInfrastructure.Repository;
using System.Threading;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
// using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using GB_project.Services.IdentityService.IdentityInfrastructure.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GB_project.Services.IdentityService.IdentityAPI.Controllers
{
    [Route("v1/api/{controller}")]
    public class SignInController : ControllerBase
    {
      private AppUserStore _userStore;

      private IConfiguration _configuration;

      private readonly MyIdentityDbContext _db;

      public SignInController(AppUserStore userStore, IConfiguration configuration, MyIdentityDbContext db)
      {
        _userStore = userStore;
        _configuration = configuration;
        _db = db;
      }

      [HttpPost]
      [ProducesResponseType(200)]
      [ProducesResponseType(400)]
      [ProducesResponseType(401)]
      public async Task<IActionResult> Authorize([FromBody]SignInViewModel model)
      {
        if(!ModelState.IsValid)
        {
          return BadRequest("Invail state");
        }

        var user = await _userStore.FindByEmailAsync(model.Email);
        if(user == null)
        {
          return StatusCode(401);
        }

        var result = await _userStore.PasswordSignInAsync(user, model.PassWord, true, false);

        if(!result.Succeeded)
        {
          return BadRequest("Password Wrong");
        }

        var token = await GenerateToken(user);
        
        return Ok(token);
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

        var user = _db.Users.Single(b => b.RefreshToken == refresh_token.RefreshToken);

        var userCopy = await  _userStore.FindByEmailAsync(user.Email);

        if(user == null)
        {
          return BadRequest("Invail refresh token");
        }

        var token = await GenerateToken(userCopy);

        return Ok(token);
      }

      private async Task<TokenViewModel> GenerateToken(AppUser user)
      {
        var expireTime = DateTime.Now.AddMinutes(Convert.ToDouble(5));
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

        IList<string> roles = _userStore.GetRolesAsync(user).GetAwaiter().GetResult();

        foreach( string role in roles)
        {
          claims.Add(new Claim(ClaimTypes.Role, role));
        }

        user.SetRefreshToken(refresh_token);

        await _userStore.UpdateAsync(user);

        var token = new JwtSecurityToken("https://localhost:5001", "GB",
                                        claims, notBefore, expireTime, cred);

        return new TokenViewModel(){ access_token = new JwtSecurityTokenHandler().WriteToken(token), refresh_token = refresh_token};
      }
    }
}
