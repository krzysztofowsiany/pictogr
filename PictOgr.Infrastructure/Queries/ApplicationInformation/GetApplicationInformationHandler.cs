using CQRS.Query;
using PictOgr.Infrastructure.DTO;
using PictOgr.Infrastructure.Services.ApplicationService;

namespace PictOgr.Infrastructure.Queries.ApplicationInformation
{
	public class GetApplicationInformationHandler : IQueryHandler<GetApplicationInformation, ApplicationInformationDto>
	{
		private readonly IApplicationService _applicationService;

		public GetApplicationInformationHandler(IApplicationService applicationService)
		{
			_applicationService = applicationService;
		}

		public ApplicationInformationDto Execute(GetApplicationInformation query)
		{
			return _applicationService.GetApplicationInformation();
		}
	}
}
