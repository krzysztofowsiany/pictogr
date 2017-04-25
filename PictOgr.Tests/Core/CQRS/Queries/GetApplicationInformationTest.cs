using CQRS.Tests;
using PictOgr.Infrastructure.AutoFac;
using PictOgr.Infrastructure.DTO;
using PictOgr.Infrastructure.Queries.ApplicationInformation;
using Ploeh.AutoFixture;

namespace PictOgr.Tests.Core.CQRS.Queries
{
	using Shouldly;
	using Xunit;

	public class GetApplicationInformationTest : QueryBaseTests<GetApplicationInformation, ApplicationInformationDto>
	{
		private readonly Fixture fixture;

		public GetApplicationInformationTest() : base(Container.CreateBuilder())
		{
			fixture = new Fixture();
		}

		[Fact]
		public void get_application_version_should_return_the_random_string()
		{
            //arragne
			var version = fixture.Create<string>();
		    var applicationInformationDto = new ApplicationInformationDto { Version = version };
		    handleMethod = () => applicationInformationDto;

            //act
			var applicationInformation = queryBus.Process<GetApplicationInformation, ApplicationInformationDto>(new GetApplicationInformation());

            //assert
			applicationInformation.Version.ShouldBe(version);
		}
	}
}
