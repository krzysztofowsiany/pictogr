using Autofac;

namespace CQRS.Tests
{
	public static class Container
	{
		public static ContainerBuilder CreateBuilder()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new CQRSModule());

			return builder;
		}
	}
}
