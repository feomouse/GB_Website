using System.Threading;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace GB_Project.Services.IdentityService.IdentityAPI.Query
{
  public class UserQuery : IUserQuery
  {
      IUserEmailStore<AppUser> UserRepo;

      IUserRoleStore<AppUser> UserRoleRepo;

      IUserStore<AppUser> UserpRepo;

      public UserQuery(IUserEmailStore<AppUser> userRepo, IUserRoleStore<AppUser> userRoleRepo, IUserStore<AppUser> userpRepo)
      {
        UserRepo = userRepo;

        UserRoleRepo = userRoleRepo;

        UserpRepo = userRepo;
      }

      public AppUser FindUserByEmail(string email)
      {
        return UserRepo.FindByEmailAsync(email, default(CancellationToken)).GetAwaiter().GetResult();
      }

      public AppUser FindUserByName(string userName)
      {
        return UserRepo.FindByNameAsync(userName, default(CancellationToken)).GetAwaiter().GetResult();
      }

      public AppUser FindUserById(string userId, string role)
      {
        var user = UserpRepo.FindByIdAsync(userId, default(CancellationToken)).GetAwaiter().GetResult();

        if(UserRoleRepo.IsInRoleAsync(user, role, default(CancellationToken)).GetAwaiter().GetResult()) {
          return user;
        } 
        return new AppUser();
      }

      public IList<String> GetRolesAsync(AppUser user)
      {
        return UserRoleRepo.GetRolesAsync(user, default(CancellationToken)).GetAwaiter().GetResult();
      }

      public AppUser GetAppUserByRefreshToken(string refreshToken)
      {
        using(var connection = new SqlConnection("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Identity;User=sa;Password=107409;"))
        {
          connection.Open();

          return connection.Query<AppUser>(@"SELECT * FROM [dbo].AspNetUsers WHERE RefreshToken = @ReToken", new {ReToken = refreshToken}).FirstOrDefault();
        }
      }
  }
}