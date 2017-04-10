namespace PictOgr.Tests.Core.CQRS.Commands
{
	using PictOgr.Core.Commands;
	using SplashScreen.Commands;
	using Shouldly;
	using Xunit;

	public class ExitApplicationCommandTest : CommandBaseTests<ExitApplication>
	{
		private readonly int expectedValue = 123;
		private int exitCode;

		public ExitApplicationCommandTest()
		{
			handleMethod = command =>
			{
				var exitApplication = command as ExitApplication;
				exitCode = exitApplication.ExitCode;
			};
		}

		[Fact]
		public void exit_application_command_should_be_handled_by_command_bus()
		{
			commandBus.SendCommand<ExitApplication>(new ExitApplication(expectedValue));

			exitCode.ShouldBe(expectedValue);
		}

		[Fact]
		public void window_command_exit_application_should_be_handle_by_command_bus()
		{
			var exitApplicationCommand = new ExitApplicationCommand(commandBus);

			exitApplicationCommand.Execute(null);

			exitCode.ShouldBe(0);
		}
	}
}