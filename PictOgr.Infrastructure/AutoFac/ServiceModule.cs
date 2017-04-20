using Autofac;
using PictOgr.Infrastructure.Services;
using PictOgr.Infrastructure.Services.ApplicationService;

namespace PictOgr.Infrastructure.AutoFac
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ApplicationService>().AsImplementedInterfaces();
		}
	}
}
