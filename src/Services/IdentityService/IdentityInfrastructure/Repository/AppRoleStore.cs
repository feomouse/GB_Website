using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using GB_project.Services.IdentityService.IdentityInfrastructure.Context;
using System.Threading.Tasks;
using GB_project.Services.IdentityService.IdentityDomin.AggregatesModel;
using System.Threading;
using System;

namespace GB_project.Services.IdentityService.IdentityInfrastructure.Repository
{
    public class AppRoleStore : IRoleStore<AppRole>
    {
      public AppRoleStore()
      {

      }
    

      public Task<IdentityResult> CreateAsync(AppRole role, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.CreateAsync(role);
      }

      public Task<IdentityResult> DeleteAsync(AppRole role, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.DeleteAsync(role);
      } 

      public Task<AppRole> FindByIdAsync(String roleId, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.FindByIdAsync(roleId);
      } 

      public Task<AppRole> FindByNameAsync(String normalizedRoleName, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.FindByNameAsync(normalizedRoleName);
      } 

      public Task<string> GetNormalizedRoleNameAsync(AppRole role, CancellationToken cancel = default(CancellationToken))
      {
         return null;
      }

      public Task<string> GetRoleIdAsync(AppRole role, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.GetRoleIdAsync(role);
      }  

      public Task<string> GetRoleNameAsync(AppRole role, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.GetRoleNameAsync(role);
      }  

      public Task SetNormalizedRoleNameAsync(AppRole role, String normalizedName, CancellationToken cancel = default(CancellationToken))
      {
        return null;
      }  

      public Task SetRoleNameAsync(AppRole role, String roleName, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.SetRoleNameAsync(role, roleName);
      } 
 
      public Task<IdentityResult> UpdateAsync(AppRole role, CancellationToken cancel = default(CancellationToken))
      {
        return DbContextExtensions.roleManager.UpdateAsync(role);
      } 


      public void Dispose()
      {
        
      }
    }
}