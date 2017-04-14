using System;
using Autofac;
using Autofac.Extras.NLog;
using PictOgr.Core.CQRS.Query;

namespace PictOgr.Core.CQRS.Bus
{
	public class QueryBus : IQueryBus
	{
		private readonly ILifetimeScope container;
		private readonly ILogger logger;

		public QueryBus(ILifetimeScope container, ILogger logger)
		{
			this.container = container;
			this.logger = logger;
		}

		public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
		{
			if (query == null)
			{
				throw new ArgumentNullException(nameof(query));
			}

			var queryHandle = container.Resolve<IQueryHandler<TQuery, TResult>>();

			if (queryHandle == null)
			{
				throw new Exception($"Not found handler for Query: '{query.GetType().FullName}'");
			}

			var result = default(TResult);

			try
			{
				result = queryHandle.Execute(query);
			}
			catch (Exception e)
			{
				logger.Error(e);
			}

			return result;
		}
	}
}
