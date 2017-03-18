using PictOgr.Core.CQRS.Query;

namespace PictOgr.Core.CQRS.Bus
{
	public interface IQueryBus
	{
		TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}
