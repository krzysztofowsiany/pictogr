using Autofac;
using PictOgr.Infrastructure;
using PictOgr.Infrastructure.AutoFac;
using Shouldly;
using Xunit;

namespace PictOgr.Tests.Database
{
	public class LiteDBTests
	{
		private readonly IContainer container;

		public LiteDBTests()
		{
			container = Container.CreateBuilder().Build();
		}

		[Fact]
		public void test_database_connection()
		{
			using (var scope = container.BeginLifetimeScope())
			{
				var database = scope.Resolve<IDatabase>();

				database.ShouldNotBeNull();
			}
		}
	}
}
