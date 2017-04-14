using System;
using Autofac;
using CQRS.Bus.Query;
using CQRS.Query;
using FakeItEasy;

namespace CQRS.Tests
{
	public class QueryBaseTests<TQuery, TResult> where TQuery : IQuery<TResult>
	{
		protected IQueryBus queryBus;

		protected Func<TResult> handleMethod;

		public QueryBaseTests(ContainerBuilder builder)
		{
			var fakeHandler = A.Fake<IQueryHandler<TQuery, TResult>>();

			A.CallTo(() => fakeHandler.Execute(A<TQuery>._)).ReturnsLazily(() => handleMethod.Invoke());

			builder.Register(c => fakeHandler).AsImplementedInterfaces();

			var container = builder.Build();

			queryBus = container.Resolve<IQueryBus>();
		}
	}
}
