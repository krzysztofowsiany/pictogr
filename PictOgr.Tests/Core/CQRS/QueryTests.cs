using Autofac;
using PictOgr.Core.AutoFac;
using Xunit;
using Shouldly;
using PictOgr.Core.Models;
using PictOgr.Core.Queries;
using PictOgr.Tests.Core.CQRS.Queries;

namespace PictOgr.Tests.Core.CQRS
{
    using PictOgr.Core.CQRS.Bus.Query;

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
		public void test_query_bus_are_correct_resolved()
		{
			var value = 220;
			var result = queryBus.Process<QueryTestClass, int>(new QueryTestClass(value));

			result.ShouldBe(value);
		}

		[Fact]
		public void test_query_application_information()
		{
			var applicationInfo =
				queryBus.Process<GetApplicationInformation, ApplicationInformation>(new GetApplicationInformation());

			applicationInfo.Version.ShouldNotBeNull();
			applicationInfo.Version.ShouldNotBeEmpty();
		}
	}
}
