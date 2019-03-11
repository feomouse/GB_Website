using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GB_Project.Services.IdentityService.IdentityInfrastructure.Context;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System;
using System.Collections.Generic;

namespace GB_Project.Services.IdentityService.IdentityInfrastructure.Repository
{
    public class AppUserStore : IUserStore<AppUser>, IUserRoleStore<AppUser>, IUserPasswordStore<AppUser>, IUserEmailStore<AppUser>, IRepository
    {
      public AppUserStore()
      {
      }

      #region IUserStore
      public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.CreateAsync(user);
      }

      public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancel = default(CancellationToken))
      {
        DbContextExtensions.userManager.RemoveFromRoleAsync(user, "Merchant").GetAwaiter().GetResult();

        return DbContextExtensions.userManager.DeleteAsync(user);
      } 

      public Task<AppUser> FindByIdAsync(String userId, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.FindByIdAsync(userId);
      } 

      public Task<AppUser> FindByNameAsync(String normalizedUserName, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.FindByNameAsync(normalizedUserName);
      } 

      public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.GetUserNameAsync(user);
      }

      public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.GetUserIdAsync(user);
      }  

      public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.GetUserNameAsync(user);
      } 

      public Task SetNormalizedUserNameAsync(AppUser user, String normalizedName, CancellationToken cancel = default(CancellationToken))
      {
        return null;
      }  

      public Task SetUserNameAsync(AppUser user, String userName, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.SetUserNameAsync(user, userName);
      } 

      public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.userManager.UpdateAsync(user);
      } 

      public void Dispose()
      {
        
      }
      #endregion
    
      #region IUserRoleStore
      public Task AddToRoleAsync (AppUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.AddToRoleAsync(user, roleName);
      }

      public Task<IdentityResult> MyAddToRoleAsync (AppUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
      {
         return DbContextExtensions.userManager.AddToRoleAsync(user, roleName);
      }

      public Task<IList<String>> GetRolesAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.GetRolesAsync(user);
      } 

      public Task<IList<AppUser>> GetUsersInRoleAsync (string roleName, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.GetUsersInRoleAsync(roleName);
      }

      public Task<Boolean> IsInRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.IsInRoleAsync(user, roleName);
      }

      public Task RemoveFromRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.RemoveFromRoleAsync(user, roleName);
      }
      #endregion
    
      #region IUserPasswordStore
      public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
         return null;
      }

      public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.HasPasswordAsync(user);
      }

      public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken = default(CancellationToken))
      {
        return null;
      } 
      #endregion
    
      #region IUserEmailStore
      public Task<AppUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.FindByEmailAsync(normalizedEmail);
      }

      public Task<string> GetEmailAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.GetEmailAsync(user);
      }

      public Task<bool> GetEmailConfirmedAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
        return null;
      }  

      public Task<string> GetNormalizedEmailAsync(AppUser user, CancellationToken cancellationToken = default(CancellationToken))
      {
        return null;
      }

      public Task SetEmailAsync(AppUser user, string email, CancellationToken cancellationToken = default(CancellationToken))
      {
        return DbContextExtensions.userManager.SetEmailAsync(user, email);
      } 

      public Task SetEmailConfirmedAsync(AppUser user, Boolean confirmed, CancellationToken cancellationToken = default(CancellationToken))
      {
        return null;
      } 

      public Task SetNormalizedEmailAsync(AppUser user, string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
      {
        return null;
      } 
      #endregion
    
      #region someElse
      // create user with password
      public Task<IdentityResult> CreateWithPasswordAsync(AppUser user, string password)
      {
        return DbContextExtensions.userManager.CreateAsync(user, password);
      }
      #endregion

      #region IRepository
      public Task<SignInResult> PasswordSignInAsync(string user, string password)
      {
        Task<SignInResult> result = DbContextExtensions.signInManager.PasswordSignInAsync(user, password, false, false);

        return result;
      }
      #endregion
    }
}