using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel
{
  public interface IRepository
  {
      Task<SignInResult> PasswordSignInAsync(AppUser user, string password, bool isPersistent, bool lockoutOnFailure);
  }
}