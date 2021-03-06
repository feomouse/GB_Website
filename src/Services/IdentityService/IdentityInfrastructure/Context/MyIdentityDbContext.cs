using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using GB_project.Services.IdentityService.IdentityDomin.AggregatesModel;

namespace GB_project.Services.IdentityService.IdentityInfrastructure.Context
{
    public class MyIdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
      public MyIdentityDbContext (DbContextOptions<MyIdentityDbContext> options): base(options)
      {

      }


      protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder)
      {
      	optionsBuilder.UseSqlServer("Server=db;Database=Identity;Integrated Security=False;User=sa;Password=1074093560cxpsvmSa!;", b => b.MigrationsAssembly("IdentityAPI"));      
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        base.OnModelCreating(builder);

        builder.Entity<AppRole>().HasData(new AppRole{Id = Guid.NewGuid(), Name = "MERCHANT", NormalizedName = "MERCHANT"});

        builder.Entity<AppUser>().HasIndex(b => b.RefreshToken).IsUnique();
      }
    }
}
