using System;
using System.Data;
using System.Data.SqlClient;
using GB_Project.Services.ManagerService.Models.AggregateRoot;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace GB_Project.Services.ManagerService.Querys
{
  public class ManagerQuery : IManagerQuery
  {
    private static string connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Manager;User=sa;Password=107409;";
 
    private SqlConnection connection = new SqlConnection(connectionString);

    public ManagerQuery()
    {
      connection.Open(); 
    }
    public ViolateUser GetViolateUserByUserName(string userName)
    {
      return connection.Query<ViolateUser>("select * from [manager].[violateUser] where Name = @Name", new { Name = userName}).FirstOrDefault();
    }

    public IEnumerable<ViolateUser> GetViolateUsers()
    {
      return connection.Query<ViolateUser>("select * from [manager].[violateUser]");
    }

    public IEnumerable<ViolateUser> GetViolateUsersIsWarned()
    {
      return connection.Query<ViolateUser>("select * from [manager].[violateUser] where IsWarned = true and IsInBlackMenu = false");
    }

    public IEnumerable<ViolateUser> GetViolateUsersIsInBlackMenu()
    {
      return connection.Query<ViolateUser>("select * from [manager].[violateUser] where IsWarned = true and IsInBlackMenu = true");
    }
  }
}