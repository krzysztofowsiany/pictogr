using CQRS.Query;

namespace CQRS.Tests.Queries
{
	public class QueryTestClassHandler : IQueryHandler<QueryTestClass, int>
	{
		public int Execute(QueryTestClass query)
		{
			return query.Value;
		}
	}
}
