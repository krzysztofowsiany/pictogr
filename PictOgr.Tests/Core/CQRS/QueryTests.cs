using System;
using Autofac;
using Xunit;
using Shouldly;
using PictOgr.Core.CQRS;
using PictOgr.Core.CQRS.Query;

namespace PictOgr.Tests.Core.CQRS
{
    public class QueryTests
    {
        private IContainer container;
        private IQueryBus query_bus;

        public QueryTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CQRSModule>();
            builder.RegisterModule<TestsModule>();
            container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                query_bus = scope.Resolve<IQueryBus>();
            }
        }

        [Fact]
        public void test_query_bus_are_correct_resolved()
        {
            var test = new QueryTest();
            var result = query_bus.Process<QueryTest, int>(test);


            result.ShouldBe(0);

        }
    }
}
