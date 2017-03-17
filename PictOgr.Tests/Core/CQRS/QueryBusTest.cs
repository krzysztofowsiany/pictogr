using System;
using Autofac;
using Xunit;
using Shouldly;
using PictOgr.Core.CQRS;
using PictOgr.Core.CQRS.Command;
using PictOgr.Core.CQRS.Query;

namespace PictOgr.Tests.Core.CQRS
{
    public class QueryBusTest
    {
        private IContainer container;

        public QueryBusTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CQRSModule>();
            container = builder.Build();
        }

        [Fact]
        public void test_query_bus_are_correct_resolved()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var query_bus = scope.Resolve<IQueryBus>();

                query_bus.ShouldBeOfType<QueryBus>();

                Should.Throw<Exception>(() =>
                {
                    query_bus.Process<QueryTest, int>(new QueryTest());
                });
            }
        }
    }
}
