using Autofac;
using AutoMapper;
using Business;
using Business.Interface;
using Portal.BD;
using Portal.Data;
using Portal.Repository;
using Repository;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace Treinamento.IOC
{
    public static class BootStrapper
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            #region Context
            builder.RegisterType<Context>()
                .AsSelf()
                .InstancePerRequest();
            #endregion

            #region automapper
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
            #endregion

            builder.SetarVidaUtilInstancia<IUsuarioBusiness, UsuarioBusiness>();
            builder.SetarVidaUtilInstancia<IUsuarioRepository, UsuarioRepository>();

        }

        public static void SetarVidaUtilInstancia<T, E>(this ContainerBuilder builder)
        {

            builder.RegisterType<E>()
            .AsSelf()
            .As<T>()
            .InstancePerRequest();
        }
    }
}
