using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GB_project.Services.MerchantService.MerchantDomin.Aggregateroot;
using GB_project.Services.MerchantService.MerchantInfrastructure.Context;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.EventBus.EventBusMQ;
using GB_Project.Services.MerchantService.MerchantAPI;
using GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.EventHandler;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MerchantAPI {
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public IServiceProvider ConfigureServices (IServiceCollection services) {
      services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

      services.AddDbContext<MerchantDbContext> (options => {
        options.UseSqlServer (Configuration.GetConnectionString ("SqlServerConnection"), b => b.MigrationsAssembly ("MerchantAPI"));
      });

      services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.ClaimsIssuer = "http://www.feowu.top:50000";
	//Configuration["Authentication:JwtIssuer"];
        options.TokenValidationParameters = new TokenValidationParameters() {
          ValidateIssuer = true,
          ValidIssuer = "http://www.feowu.top:50000",
	  //Configuration["Authentication:JwtIssuer"],
          ValidateAudience = true,
          ValidAudience = "GB",
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				  //Configuration["Authentication:JwtKey"]
				  "Group_Buy_Website_Token_Key")),
          RequireExpirationTime = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        };
      });


      services.AddSingleton<IRabbitMqPersistConnection> (sp => {
        var factory = new ConnectionFactory ();

        factory.HostName = "rabbitmq";
        factory.UserName = "guest";
        factory.Password = "guest";
        factory.VirtualHost = "/";

        //factory.Uri = "amqp://guest:guest@rabbitmq:5672/";
        return new DefaultRabbitMqPersistConnection (factory);
      });

      services.AddSingleton<IEventSubscriptionsManager, InMemorySubscriptionsManager> ();

      services.AddSingleton<IMerchantRepository, MerchantRepository> ();

      services.AddSingleton<IEventBusSubscriber, RabbitMqEventBusSubscriber> (sp => {
        var connectionFactory = sp.GetRequiredService<IRabbitMqPersistConnection> ();
        var subscriptionManager = sp.GetRequiredService<IEventSubscriptionsManager> ();
        var scope = sp.GetRequiredService<ILifetimeScope> ();
        return new RabbitMqEventBusSubscriber ("GB_Merchant", connectionFactory, subscriptionManager, scope);
      });

      services.AddTransient<MerchantRegisteredIntergrationEventHandler> ();

      var builder = new ContainerBuilder ();

      builder.Populate (services);

      return new AutofacServiceProvider (builder.Build ());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
      } else {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts ();
      }

      app.UseHttpsRedirection ();
      app.UseMvc ();

      var eventBusSubscriber = app.ApplicationServices.GetRequiredService<IEventBusSubscriber> ();
      eventBusSubscriber.Subscribe<MerchantRegisteredIntergrationEvent, MerchantRegisteredIntergrationEventHandler> ();
    }
  }
}
