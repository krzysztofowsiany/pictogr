namespace PictOgr.Core.CQRS.Bus.Query
{
    using CQRS.Query;

    public interface IQueryBus
	{
		TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}
