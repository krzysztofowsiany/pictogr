using AutoMapper;
using PictOgr.Core.Domain;
using PictOgr.Core.Repositories;
using PictOgr.Infrastructure.DTO;

namespace PictOgr.Infrastructure.Services.ApplicationService
{
	public class ApplicationService : IApplicationService
	{
		private readonly IApplicationInformationRepository _applicationInformationRepository;
		private readonly IMapper _mapper;

		public ApplicationService(
			IApplicationInformationRepository applicationInformationRepository,
			IMapper mapper)
		{
			_applicationInformationRepository = applicationInformationRepository;
			_mapper = mapper;
		}

		public ApplicationInformationDto GetApplicationInformation()
		{
			var applicationInformation = _applicationInformationRepository.GetApplicationInformation();

			return _mapper.Map<ApplicationInformation, ApplicationInformationDto>(applicationInformation);
		}
	}
}
