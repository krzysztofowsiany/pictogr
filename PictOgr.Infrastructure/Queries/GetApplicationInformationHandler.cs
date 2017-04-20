using System.Reflection;
using CQRS.Query;
using PictOgr.Core.Domain;

namespace PictOgr.Infrastructure.Queries
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
