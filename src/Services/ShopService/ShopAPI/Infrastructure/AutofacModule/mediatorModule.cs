using Autofac;
using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Command;
using System;
using System.Reflection;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure
{
    public class mediatorModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(CreateShopCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>)).AsImplementedInterfaces();

        // request & notification handlers              
        builder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });
      }
    } 
}