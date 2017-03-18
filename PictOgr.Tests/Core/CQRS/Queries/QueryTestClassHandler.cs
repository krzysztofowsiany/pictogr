using PictOgr.Core.CQRS.Query;

namespace PictOgr.Tests.Core.CQRS.Queries
{
	public class QueryTestClassHandler : IQueryHandler<QueryTestClass, int>
	{
		public int Execute(QueryTestClass query)
		{
			return query.Value;
		}
	}
}
