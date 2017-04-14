using Autofac;
using CQRS.Bus.Query;
using PictOgr.Core.AutoFac;
using PictOgr.Core.Models;
using PictOgr.Core.Queries;
using Shouldly;
using Xunit;

namespace PictOgr.Tests.Core.CQRS.Queries
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
		public void test_query_application_information()
		{
			var applicationInfo =
				queryBus.Process<GetApplicationInformation, ApplicationInformation>(new GetApplicationInformation());

			applicationInfo.Version.ShouldNotBeNull();
			applicationInfo.Version.ShouldNotBeEmpty();
		}
	}
}
