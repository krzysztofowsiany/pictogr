using System;
using Autofac;
using PictOgr.Core.CQRS.Bus;
using PictOgr.Core.CQRS.Command;
using PictOgr.Core.CQRS.Query;
using Module = Autofac.Module;

namespace PictOgr.Core.CQRS
{
    using PictOgr.Core.CQRS.Event;

    public class CQRSModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterCommands(builder);
            RegisterQueries(builder);
            RegisterEvents(builder);
        }

        private void RegisterEvents(ContainerBuilder builder)
        {
            builder.RegisterType<EventBus>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IEventHandler<>)).PropertiesAutowired();
        }


        private void RegisterQueries(ContainerBuilder builder)
        {
            builder.RegisterType<QueryBus>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .SingleInstance().PropertiesAutowired();
        }

        private void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<ICommandHandler>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, ICommandHandler>>(c =>
            {
                var context = c.Resolve<IComponentContext>();

                return type =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(type);
                    return (ICommandHandler)context.Resolve(handlerType);
                };
            });
        }
    }
}
