using MediatR;
using Autofac;
using GB_Project.Services.CommentService.CommentAPI.Application.Commands;
using System.Reflection;

namespace GB_Project.Services.CommentService.CommentAPI.Module.MediatRModule
{
  public class MediatRModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
      builder.RegisterAssemblyTypes(typeof(AddUserCommentCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>)).AsImplementedInterfaces();
    
      builder.Register<ServiceFactory>(context => {
        var c = context.Resolve<IComponentContext>();
        return t => c.Resolve(t);
      });
    }
  }
}