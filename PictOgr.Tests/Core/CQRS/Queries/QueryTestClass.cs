using PictOgr.Core.CQRS.Query;

namespace PictOgr.Tests.Core.CQRS.Queries
{
	public class QueryTestClass : IQuery<int>
	{
		public int Value { get; private set; }

		public QueryTestClass(int value)
		{
			Value = value;
		}
	}
}
