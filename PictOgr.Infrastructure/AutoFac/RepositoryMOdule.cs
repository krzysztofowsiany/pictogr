using Autofac;
using PictOgr.Infrastructure.Repositories;

namespace PictOgr.Infrastructure.AutoFac
{
	public class RepositoryModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ApplicationInformationRepository>().AsImplementedInterfaces();
		}
	}
}
