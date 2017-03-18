using Autofac;
using PictOgr.Core.CQRS.Query;
using Module = Autofac.Module;

namespace PictOgr.Tests
{
	public class TestsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterAssemblyTypes(ThisAssembly)
					.AsClosedTypesOf(typeof(IQueryHandler<,>))
					.SingleInstance().PropertiesAutowired();
		}
	}
}
