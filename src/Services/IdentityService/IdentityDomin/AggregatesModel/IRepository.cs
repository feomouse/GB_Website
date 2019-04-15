using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
  public interface IRepository
  {
      Task<SignInResult> PasswordSignInAsync(string user, string password);

      Task<SignInResult> CheckPasswordSignInAsync(string userName, string password);
  }
}