namespace PictOgr.Tests.Core.CQRS.Queries
{
    using PictOgr.Core.Models;
    using PictOgr.Core.Queries;
    using Ploeh.AutoFixture;
    using Shouldly;
    using Xunit;

    public class GetApplicationInformationTest : QueryBaseTests<GetApplicationInformation, ApplicationInformation>
    {
        private readonly Fixture fixture;

        public GetApplicationInformationTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void get_application_version_should_return_the_random_string()
        {
            var version = fixture.Create<string>();
            handleMethod = () => new ApplicationInformation(version);

            var applicationInformation = queryBus.Process<GetApplicationInformation, ApplicationInformation>(new GetApplicationInformation());

            applicationInformation.Version.ShouldBe(version);
        }
    }
}
