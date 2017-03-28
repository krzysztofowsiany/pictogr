namespace PictOgr.Tests.Core.CQRS.Commands
{
    using Autofac;
    using FakeItEasy;
    using PictOgr.Core.AutoFac;
    using PictOgr.Core.Commands;
    using PictOgr.Core.CQRS.Bus;
    using PictOgr.Core.CQRS.Command;
    using Shouldly;
    using Xunit;

    public class ExitCommandTest
    {
        private IContainer container;

        private readonly int expectedValue = 123;

        public ExitCommandTest()
        {
           var  builder = Container.CreateBuilder();

            var fakeHandler = A.Fake<ICommandHandler<ExitApplication>>();

            A.CallTo(() => fakeHandler.Handle(A<ExitApplication>._))
                .Invokes(
                    (ExitApplication exitApp) =>
                    {
                        exitApp.ExitCode.ShouldBe(expectedValue);
                    });

            builder.Register(c => fakeHandler).AsImplementedInterfaces();
            container = builder.Build();
        }

        [Fact]
        public void exit_application_command_should_be_handled_by_command_bus()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var commandBus = scope.Resolve<ICommandBus>();

                commandBus.SendCommand<ExitApplication>(new ExitApplication(expectedValue));

            }
        }
    }
}