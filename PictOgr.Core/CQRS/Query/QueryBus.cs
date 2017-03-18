using System;
using Autofac;

namespace PictOgr.Core.CQRS.Query
{
	public class QueryBus : IQueryBus
	{
		private readonly ILifetimeScope container;

		public QueryBus(ILifetimeScope container)
		{
			this.container = container;
		}

		public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
		{
			var queryHandle = container.Resolve<IQueryHandler<TQuery, TResult>>();

			if (queryHandle == null)
			{
				throw new Exception($"Not found handler for Query: '{query.GetType().FullName}'");
			}

			return queryHandle.Execute(query);
		}
	}
}
