using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using GB_Project.Services.IdentityService.IdentityDomin.AggregatesModel;

namespace GB_Project.Services.IdentityService.IdentityInfrastructure.Context
{
    public class MyIdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
      public MyIdentityDbContext (DbContextOptions<MyIdentityDbContext> options): base(options)
      {

      }


      protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder)
      {
      	optionsBuilder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Identity;Integrated Security=False;User=sa;Password=107409;", b => b.MigrationsAssembly("IdentityAPI"));      
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        base.OnModelCreating(builder);

        builder.Entity<AppRole>().HasData(new AppRole("MERCHANT"));

        builder.Entity<AppUser>().HasIndex(b => b.RefreshToken).IsUnique();
      }
    }
}
