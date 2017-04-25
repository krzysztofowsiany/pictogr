namespace PictOgr.Infrastructure.Services.DatabaseService
{
    using System.Collections.Generic;

    public interface IDatabaseService
    {
	    bool Insert<TData>(TData objectToInsert);

	    IList<TData> FetchAll<TData>();

        bool Delete<TData>(TData objectToDelete);
    }
}