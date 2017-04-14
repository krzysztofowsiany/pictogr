using CQRS.Query;

namespace CQRS.Tests.Queries
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
