namespace PictOgr.Tests.Core.CQRS
{
    using System;
    using Autofac;
    using PictOgr.Core.AutoFac;
    using Xunit;
    using Shouldly;
    using PictOgr.Core.CQRS.Query;
    using PictOgr.Core.CQRS.Bus.Query;

    public class QueryBusTest
	{
		private readonly IContainer container;

		public QueryBusTest()
		{
			container = Container.CreateBuilder().Build();
		}

		[Fact]
		public void test_query_bus_are_correct_resolved()
		{
			using (var scope = container.BeginLifetimeScope())
			{
				var queryBus = scope.Resolve<IQueryBus>();

				queryBus.ShouldBeOfType<QueryBus>();

				Should.Throw<Exception>(() =>
				{
					queryBus.Process<QueryTestNotInContainer, int>(new QueryTestNotInContainer());
				});
			}
		}

		internal class QueryTestNotInContainer : IQuery<int>
		{
		}
	}
}