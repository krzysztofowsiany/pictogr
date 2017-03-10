using System;
using Autofac;
using Xunit;
using Shouldly;
using FakeItEasy;
using PictOgr.Core.AutoFac;
using PictOgr.Core.CQRS.Command;
using PictOgr.Core.CQRS.Query;

namespace PictOgr.Tests.Core.CQRS
{
	public class query_bus_test
	{
		private IContainer container;

		public query_bus_test()
		{
			container = Container.CreateBuilder().Build();
		}

		[Fact]
		public void test_command_bus()
		{
			//Arragne
			using (var scope = container.BeginLifetimeScope())
			{
				//Act
				var query_bus = scope.Resolve<IQueryBus>();

				//Assert
				query_bus.ShouldBeOfType<QueryBus>();
			}
		}

		[Fact]
		public void test_simple_test_query_throw_exception()
		{
			//Arragne
			using (var scope = container.BeginLifetimeScope())
			{
				//Act
				var query_bus = scope.Resolve<IQueryBus>();

				//Assert
				Should.Throw<Exception>(() =>
				{
					query_bus.Process<QueryTest, int>(new QueryTest());
				});
			}
		}
	}
}
