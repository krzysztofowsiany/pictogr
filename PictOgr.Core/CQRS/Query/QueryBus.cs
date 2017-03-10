using System.ComponentModel;

namespace PictOgr.Core.CQRS.Query
{
    public class QueryBus:IQueryBus
    {
        public QueryBus()
        {
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var queryHandle = resolver.ResolveOptional<IQueryHandler<TQuery, TResult>>();

            if (queryHandle != null)
            {
                return queryHandle.Execute(query);
            }




        }
    }
}
