using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using GB_project.Services.IdentityService.IdentityInfrastructure.Context;
using GB_project.Services.IdentityService.IdentityDomin.AggregatesModel;
using Microsoft.AspNetCore.Identity;
using GB_project.Services.IdentityService.IdentityInfrastructure.Repository;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RabbitMQ.Client;
using GB_Project.EventBus.EventBusMQ;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GB_Project.EventBus.BasicEventBus;

namespace IdentityAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyIdentityDbContext>(); 
            
	    services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<MyIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options => {
              options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
              options.RequireHttpsMetadata = false;
              options.SaveToken = true;
              options.ClaimsIssuer = "http://www.feowu.top:50000";
	     // Configuration["Authentication:JwtIssuer"];
              options.TokenValidationParameters = new TokenValidationParameters() {
                ValidateIssuer = true,
                ValidIssuer = "http://www.feowu.top:50000",
		//Configuration["Authentication:JwtIssuer"],
                ValidateAudience = true,
                ValidAudience = "GB",
		//Configuration["Authentication:JwtAudience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Group_Buy_Website_Token_Key"
					//Configuration["Authentication:JwtKey"]
					)),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
              };
            });

            services.AddSingleton<IRabbitMqPersistConnection>(sp =>
            {
              var connectionFactory = new ConnectionFactory();

              connectionFactory.HostName = "rabbitmq";
              connectionFactory.UserName = "guest";
              connectionFactory.Password = "guest";
              connectionFactory.VirtualHost = "/";

              //connectionFactory.Uri = "amqp://guest:guest@rabbitmq:5672/";
              return new DefaultRabbitMqPersistConnection(connectionFactory);
            });

            services.AddSingleton<IEventSubscriptionsManager, InMemorySubscriptionsManager>();

            services.AddSingleton<IEventBusPublisher, RabbitMqEventBusPublisher>(sp =>
            {
              var factory = sp.GetRequiredService<IRabbitMqPersistConnection>();
              var manager = sp.GetRequiredService<IEventSubscriptionsManager>();
              return new RabbitMqEventBusPublisher(factory, manager);
            });

            var provider = services.BuildServiceProvider();
            DbContextExtensions.userManager = provider.GetService<UserManager<AppUser>>();
            DbContextExtensions.roleManager = provider.GetService<RoleManager<AppRole>>();
            DbContextExtensions.signInManager = provider.GetService<SignInManager<AppUser>>();

            services.AddTransient<AppRoleStore>();
            services.AddTransient<AppUserStore>();

            // var builder = new ContainerBuilder();

            // builder.Populate(services);

            // return new AutofacServiceProvider(builder.Build());
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
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
