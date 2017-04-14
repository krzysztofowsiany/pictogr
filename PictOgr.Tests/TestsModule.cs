namespace PictOgr.Tests
{
	using Autofac;
	using CQRS.Query;

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
