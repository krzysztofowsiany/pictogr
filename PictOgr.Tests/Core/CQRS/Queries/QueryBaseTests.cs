namespace PictOgr.Tests.Core.CQRS.Queries
{
    using System;
    using Autofac;
    using FakeItEasy;
    using PictOgr.Core.AutoFac;
    using PictOgr.Core.CQRS.Bus;
    using PictOgr.Core.CQRS.Query;

    public class QueryBaseTests<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected IQueryBus queryBus;

        protected Func<TResult> handleMethod;

        public QueryBaseTests()
        {
            var builder = Container.CreateBuilder();

            var fakeHandler = A.Fake<IQueryHandler<TQuery, TResult>>();

            A.CallTo(() => fakeHandler.Execute(A<TQuery>._)).ReturnsLazily(() => handleMethod.Invoke());

            builder.Register(c => fakeHandler).AsImplementedInterfaces();

            var container = builder.Build();

            queryBus = container.Resolve<IQueryBus>();
        }
    }
}
