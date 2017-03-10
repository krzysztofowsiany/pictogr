using Autofac;
using PictOgr.Core.CQRS.Command;
using PictOgr.Core.CQRS.Query;

namespace PictOgr.Core.CQRS
{
    public class CQRSModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new CommandBus(c)).As<ICommandBus>().SingleInstance();
            builder.Register(c => new QueryBus(c)).As<IQueryBus>().SingleInstance();
        }
    }
}
