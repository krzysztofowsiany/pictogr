namespace PictOgr.Tests.Database
{
    using Autofac;
    using Infrastructure.AutoFac;
    using Xunit;
    using Infrastructure.Services.DatabaseService;
    using Shouldly;

    public class CreateDatabaseServiceTest
    {
        private readonly IContainer container;

        public CreateDatabaseServiceTest()
        {
            container = Container.CreateBuilder().Build();
        }

        [Fact]
        public void test_database_service_creation()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var database = scope.Resolve<IDatabaseService>();

                database.ShouldNotBeNull();
            }
        }
    }
}
