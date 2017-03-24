using System;
using Autofac;
using PictOgr.Core.CQRS.Bus;
using PictOgr.Core.CQRS.Command;
using PictOgr.Core.CQRS.Query;
using Module = Autofac.Module;

namespace PictOgr.Core.CQRS
{
    public class CQRSModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterCommands(builder);
            RegisterQueriess(builder);
        }

        private void RegisterQueriess(ContainerBuilder builder)
        {
            builder.RegisterType<QueryBus>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .SingleInstance().PropertiesAutowired();
        }

        private void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<ICommandHandler>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, ICommandHandler>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                    return (ICommandHandler)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<CommandBus>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
