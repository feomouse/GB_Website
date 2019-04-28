﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GB_Project.Services.ShopService.ShopInfrastructure.Context;
using RabbitMQ.Client;
using GB_Project.EventBus.EventBusMQ;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.EventHandlers;
using GB_Project.Services.ShopService.ShopAPI.IntergrationEvents.Events;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;

namespace ShopAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        //public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        
            services.AddDbContext<ShopDbContext>();

/*             services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
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

            services.AddSingleton<IRabbitMqPersistConnection>(op => {
                var factory = new ConnectionFactory ();

                factory.HostName = "localhost";
                factory.UserName = "guest";
                factory.Password = "guest";
                factory.VirtualHost = "/";

                //factory.Uri = "amqp://guest:guest@rabbitmq:5672/";
                return new DefaultRabbitMqPersistConnection (factory);
            });

            services.AddSingleton<IEventSubscriptionsManager, InMemorySubscriptionsManager>();

            services.AddSingleton<IEventBusPublisher, RabbitMqEventBusPublisher>(op => {
              var connection = op.GetRequiredService<IRabbitMqPersistConnection>();
              var manager = op.GetRequiredService<IEventSubscriptionsManager>();
              return new RabbitMqEventBusPublisher(connection, manager);
            });

            services.AddSingleton<IEventBusSubscriber, RabbitMqEventBusSubscriber>(op => {
                var factory = op.GetRequiredService<IRabbitMqPersistConnection>();
                var manager = op.GetRequiredService<IEventSubscriptionsManager>();
                var scope = op.GetRequiredService<ILifetimeScope> ();
                return new RabbitMqEventBusSubscriber("GB_Shop", factory, manager, scope);
            });

            services.AddTransient<MerchantIsIdentitiedIntergrationEventHandler>();
            services.AddTransient<IncreOrderSellIntergrationEventHandler>();

            services.AddSingleton<IShopQuery, ShopQuery>();
            services.AddSingleton<IShopRepository, ShopRepository>();

            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterModule(new mediatorModule());

            builder.RegisterModule(new ApplicationModule());

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer); 
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            var sub = app.ApplicationServices.GetRequiredService<IEventBusSubscriber>();
            sub.Subscribe<MerchantIsIdentitiedIntergrationEvent, MerchantIsIdentitiedIntergrationEventHandler>();
            sub.Subscribe<IncreOrderSellIntergrationEvent, IncreOrderSellIntergrationEventHandler>();
        }
    }
}
