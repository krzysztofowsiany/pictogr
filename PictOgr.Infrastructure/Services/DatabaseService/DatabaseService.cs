namespace PictOgr.Infrastructure.Services.DatabaseService
{
    using System.Collections.Generic;

    public class DatabaseService : IDatabaseService
    {
        public bool Insert<TData>(TData objectToInsert)
        {
            return false;
        }

        public IList<TData> FetchAll<TData>()
        {
            return null;
        }

        public bool Delete<TData>(TData objectToDelete)
        {
            return false;
        }
    }
}
