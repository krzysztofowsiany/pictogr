using Autofac;

using PictOgr.Infrastructure.Services.ApplicationService;

namespace PictOgr.Infrastructure.AutoFac
{
    using PictOgr.Infrastructure.Services.DatabaseService;

    public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ApplicationService>().AsImplementedInterfaces();
            builder.RegisterType<DatabaseService>().AsImplementedInterfaces();
        }
	}
}
