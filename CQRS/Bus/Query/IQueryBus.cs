using CQRS.Query;

namespace CQRS.Bus.Query
{
	public interface IQueryBus
	{
		TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}
