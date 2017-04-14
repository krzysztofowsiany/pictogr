namespace PictOgr.Core.Queries
{
	using System.Reflection;
	using CQRS.Query;
	using Models;

	public class GetApplicationInformationHandler : IQueryHandler<GetApplicationInformation, ApplicationInformation>
	{
		public ApplicationInformation Execute(GetApplicationInformation query)
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version;

			return new ApplicationInformation($"{version.Major}.{version.Minor}.{version.Build}");
		}
	}
}
