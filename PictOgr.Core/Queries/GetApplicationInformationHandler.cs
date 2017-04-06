using System.Reflection;
using PictOgr.Core.CQRS.Query;
using PictOgr.Core.Models;

namespace PictOgr.Core.Queries
{
	public class GetApplicationInformationHandler : IQueryHandler<GetApplicationInformation, ApplicationInformation>
	{
		public ApplicationInformation Execute(GetApplicationInformation query)
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version;

			return new ApplicationInformation($"{version.Major}.{version.Minor}.{version.Build}");
		}
	}
}
