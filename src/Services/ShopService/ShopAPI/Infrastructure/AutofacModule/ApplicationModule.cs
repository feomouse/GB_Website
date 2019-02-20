using Autofac;
using MediatR;
using GB_project.Services.ShopService.ShopAPI.Application.Command;
using System;
using System.Reflection;
using GB_project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_project.Services.ShopService.ShopInfrastructure.Repository;
using GB_project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_project.Services.ShopService.ShopAPI.Infrastructure
{
    public class ApplicationModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<readQuery>().As<IQuery>();

        builder.RegisterType<ShopRepository>().As<IShopRepository>();
      }
    } 
}