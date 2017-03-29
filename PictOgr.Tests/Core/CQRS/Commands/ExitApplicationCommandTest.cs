namespace PictOgr.Tests.Core.CQRS.Commands
{
    using PictOgr.Core.Commands;
    using Shouldly;
    using Xunit;

    public class ExitApplicationCommandTest : CommandBaseTests<ExitApplication>
    {
        private readonly int expectedValue = 123;
        private int exitCode;

        [Fact]
        public void exit_application_command_should_be_handled_by_command_bus()
        {
            handleMethod = command =>
            {
                var exitApplication = command as ExitApplication;
                exitCode = exitApplication.ExitCode;
            };

            commandBus.SendCommand<ExitApplication>(new ExitApplication(expectedValue));

            exitCode.ShouldBe(expectedValue);
        }
    }
}