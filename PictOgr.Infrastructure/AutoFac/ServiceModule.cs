using Autofac;
using PictOgr.Infrastructure.Services;

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
