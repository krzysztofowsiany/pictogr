using System;
using System.Reflection;
using PictOgr.Core.Domain;
using PictOgr.Core.Repositories;

namespace PictOgr.Infrastructure.Repositories
{
	public class ApplicationInformationRepository: IApplicationInformationRepository
	{
		public ApplicationInformation GetApplicationInformation()
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			return new ApplicationInformation($"{version.Major}.{version.Minor}.{version.Build}");
		}
	}
}
