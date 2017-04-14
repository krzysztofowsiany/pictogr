using Autofac;
using CQRS.Bus.Query;
using Shouldly;
using Xunit;

namespace CQRS.Tests.Queries
{
	public class QueryTests
	{
		private readonly IQueryBus queryBus;

		public QueryTests()
		{
			var container = Container.CreateBuilder().Build();

			using (var scope = container.BeginLifetimeScope())
			{
				queryBus = scope.Resolve<IQueryBus>();
			}
		}

		[Fact]
		public void test_query_bus_are_correct_process()
		{
			var value = 220;
			var result = queryBus.Process<QueryTestClass, int>(new QueryTestClass(value));

			result.ShouldBe(value);
		}
	}
}
