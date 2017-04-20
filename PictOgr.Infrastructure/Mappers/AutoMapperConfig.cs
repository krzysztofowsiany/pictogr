
using AutoMapper;
using PictOgr.Core.Domain;
using PictOgr.Infrastructure.DTO;

namespace PictOgr.Infrastructure.Mappers
{
	public static class AutoMapperConfig
	{
		public static IMapper Initialize() => new MapperConfiguration(config =>
		{
			config.CreateMap<ApplicationInformation, ApplicationInformationDto>();
			config.CreateMap<ApplicationInformationDto, ApplicationInformation>();

		}).CreateMapper();
	}
}
