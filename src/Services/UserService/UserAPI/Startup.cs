using System;
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
using GB_Project.Services.UserService.UserInfrastructure.Context;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GB_Project.Services.UserService.UserAPI.Query;
using GB_Project.Services.UserService.UserDomin.UserAggregateModel;
using GB_Project.Services.UserService.UserInfrastructure.Repository;
using GB_Project.Services.UserService.UserAPI.Modules;
using RabbitMQ.Client;
using GB_Project.Services.UserService.UserAPI.IntergrationEvents.Events;
using GB_Project.Services.UserService.UserAPI.IntergrationEvents.EventsHandler;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.EventBus.EventBusMQ;
using Swashbuckle.AspNetCore.Swagger;
namespace UserAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<UserDbContext>();

            services.AddSingleton<IUserQuery, UserQuery>();

            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<IEventSubscriptionsManager, InMemorySubscriptionsManager>();

            services.AddSingleton<IRabbitMqPersistConnection>(sp => {
                var factory = new ConnectionFactory();
                factory.UserName = "guest";
                factory.Password = "guest";
                factory.VirtualHost = "/";
                factory.HostName = "localhost";

                return new DefaultRabbitMqPersistConnection(factory);
            });

            services.AddSingleton<IEventBusSubscriber, RabbitMqEventBusSubscriber>(sp => {
                var scope = sp.GetRequiredService<ILifetimeScope>();
                var connection = sp.GetRequiredService<IRabbitMqPersistConnection>();
                var manager = sp.GetRequiredService<IEventSubscriptionsManager>();

                return new RabbitMqEventBusSubscriber("GB_USER", connection, manager, scope);
            });

            services.AddTransient<UserRegisteredIntergrationEventHandler>();

            services.AddSwaggerGen(c => 
            {
              c.SwaggerDoc("v1", new Info{ Title = "My User api", Version = "v1"});
            });

            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterModule(new MediatRModule());

            return new AutofacServiceProvider(builder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCors();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "my api v1");
            });

            var subscriber = app.ApplicationServices.GetRequiredService<IEventBusSubscriber>();
            subscriber.Subscribe<UserRegisteredIntergrationEvent, UserRegisteredIntergrationEventHandler>();
        }
    }
}
