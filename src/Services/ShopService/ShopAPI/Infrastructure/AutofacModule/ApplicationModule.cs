using Autofac;
using MediatR;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System;
using System.Reflection;
using GB_Project.Services.ShopService.ShopAPI.Infrastructure.Queries;
using GB_Project.Services.ShopService.ShopInfrastructure.Repository;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Infrastructure
{
    public class ApplicationModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
/*         builder.RegisterType<ShopQuery>().As<IShopQuery>();

        builder.RegisterType<ShopRepository>().As<IShopRepository>(); */
      }
    } 
}