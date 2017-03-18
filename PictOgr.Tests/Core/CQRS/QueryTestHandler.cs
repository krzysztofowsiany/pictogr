using PictOgr.Core.CQRS.Query;

namespace PictOgr.Tests.Core.CQRS
{
    public class QueryTestHandler: IQueryHandler<QueryTest, int>
    {
        public int Execute(QueryTest query)
        {
            
            return 0;
        }
    }
}
