using Autofac;

namespace PictOgr.Infrastructure.AutoFac
{
	public class DatabaseModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<Database>().AsImplementedInterfaces();
		}
	}
}
