using Autofac;
using MediatR;
using System.Reflection;
using GB_Project.Services.IdentityService.IdentityAPI.Application.Commands;

namespace GB_Project.Services.IdentityService.IdentityAPI.Modules
{
  public class MediatRModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder modelBuilder)
    {
      modelBuilder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

      modelBuilder.RegisterAssemblyTypes(typeof(RegistryCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>)).AsImplementedInterfaces();

      modelBuilder.Register<ServiceFactory>(context => {
        var c = context.Resolve<IComponentContext>();
        return t => c.Resolve(t);
      });
    }
  }
}