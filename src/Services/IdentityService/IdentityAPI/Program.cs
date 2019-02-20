using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using GB_project.Services.IdentityService.IdentityInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

	    using(var scope = host.Services.CreateScope())
            {
	      var services = scope.ServiceProvider;
	      var dbContext = services.GetRequiredService<MyIdentityDbContext>();
	      dbContext.Database.Migrate();
	    }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
