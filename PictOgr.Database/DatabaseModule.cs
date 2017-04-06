using Autofac;
using PictOgr.Database;

namespace PictOgr.Core
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Database.Database>().AsImplementedInterfaces();

        }
    }
}
