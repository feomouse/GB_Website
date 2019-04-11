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
using GB_Project.Services.CommentService.CommentInfrastructrue.Context;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GB_Project.Services.CommentService.CommentAPI.Module.MediatRModule;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using GB_Project.Services.CommentService.CommentInfrastructrue.Repository;
using GB_Project.Services.CommentService.CommentAPI.CommentQuery;
using RabbitMQ.Client;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using GB_Project.EventBus.BasicEventBus;
using GB_Project.EventBus.EventBusMQ;
using GB_Project.Services.CommentService.CommentAPI.Intergration.Events;

namespace CommentAPI
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

            services.AddDbContext<CommentContext>();

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

            services.AddSingleton<ICommentRepository, CommentRepository>();

            services.AddSingleton<IQuery, CommentQuery>();

            var builder = new ContainerBuilder ();

            builder.Populate(services);

            builder.RegisterModule(new MediatRModule());

            return new AutofacServiceProvider (builder.Build ());
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
        }
    }
}
