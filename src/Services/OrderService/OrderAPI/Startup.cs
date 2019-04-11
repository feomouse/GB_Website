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
using GB_Project.Services.OrderService.OrderInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Autofac;
using GB_Project.Services.OrderService.OrderAPI.Modules.DIModule;
using Autofac.Extensions.DependencyInjection;
using GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate;
using GB_Project.Services.OrderService.OrderInfrastructure.OrderRepository;
using GB_Project.Services.OrderService.OrderAPI.GetQuery;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.EventBus.EventBusMQ;
using RabbitMQ.Client;
using GB_Project.Services.OrderService.OrderAPI.Intergration.Events;
using GB_Project.Services.OrderService.OrderAPI.Intergration.EventsHandler;

namespace OrderAPI
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
            services.AddDbContext<OrderDbContext>();
            services.AddSingleton<IGBOrderRepository, OrderRepository>();
            services.AddSingleton<IGBQuery, GBQuery>();

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

            services.AddSingleton<IEventBusPublisher, RabbitMqEventBusPublisher> (sp => {
                var connectionFactory = sp.GetRequiredService<IRabbitMqPersistConnection> ();
                var manager = sp.GetRequiredService<IEventSubscriptionsManager>();
                return new RabbitMqEventBusPublisher(connectionFactory, manager);
            });

            services.AddSingleton<IEventBusSubscriber, RabbitMqEventBusSubscriber> (sp => {
                var connectionFactory = sp.GetRequiredService<IRabbitMqPersistConnection> ();
                var subscriptionManager = sp.GetRequiredService<IEventSubscriptionsManager> ();
                var scope = sp.GetRequiredService<ILifetimeScope> ();
                return new RabbitMqEventBusSubscriber ("GB_Order", connectionFactory, subscriptionManager, scope);
            });

            services.AddTransient<AddCommentIntergrationEventHandler>();

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

            app.UseHttpsRedirection();
            app.UseMvc();

            var sub = app.ApplicationServices.GetRequiredService<IEventBusSubscriber>();

            sub.Subscribe<AddCommentIntergrationEvent, AddCommentIntergrationEventHandler>();
        }
    }
}
