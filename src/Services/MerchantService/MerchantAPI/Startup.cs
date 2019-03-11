using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Context;
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
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using GB_Project.Services.MerchantService.MerchantAPI.Modules;
using Swashbuckle.AspNetCore.Swagger;

namespace MerchantAPI {
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public IServiceProvider ConfigureServices (IServiceCollection services) {
      services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

      services.AddDbContext<MerchantDbContext> ();

/*       services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.ClaimsIssuer = Configuration["Authentication:JwtIssuer"];
        options.TokenValidationParameters = new TokenValidationParameters() {
          ValidateIssuer = true,
          ValidIssuer = Configuration["Authentication:JwtIssuer"],
          ValidateAudience = true,
          ValidAudience = "GB",
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtKey"])),
          RequireExpirationTime = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        };
      }); */

      services.AddSingleton<IRabbitMqPersistConnection> (sp => {
        var factory = new ConnectionFactory ();

        factory.HostName = "localhost";
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

      services.AddSingleton<IMerchantQuery, MerchantQuery>();

      services.AddSwaggerGen(c => 
      {
        c.SwaggerDoc("v1", new Info {Title = "My Merchnt Api", Version = "v1"});
      });

      var builder = new ContainerBuilder ();

      builder.Populate (services);

      builder.RegisterModule(new MediatRModule());

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

      app.UseSwagger();
      app.UseSwaggerUI(c => 
      {
        c.SwaggerEndpoint("v1/swagger.json", "My Merchant Api");
      });

      var eventBusSubscriber = app.ApplicationServices.GetRequiredService<IEventBusSubscriber> ();
      eventBusSubscriber.Subscribe<MerchantRegisteredIntergrationEvent, MerchantRegisteredIntergrationEventHandler> ();
    }
  }
}
