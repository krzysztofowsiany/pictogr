namespace CQRS.Tests.Commands
{
	using System;
	using Autofac;
	using Bus.Command;
	using Command;
	using FakeItEasy;
	using Shouldly;
	using Xunit;

	public class CommandBusTest
	{
		private readonly IContainer container;

		public CommandBusTest()
		{
			container = Container.CreateBuilder().Build();
		}

		[Fact]
		public void test_command_bus_are_correct_resolved()
		{
			using (var scope = container.BeginLifetimeScope())
			{
				var commandBus = scope.Resolve<ICommandBus>();

				commandBus.ShouldBeOfType<CommandBus>();

				Should.Throw<Exception>(() =>
					{
						var fakeCommand = A.Fake<ICommand>();
						commandBus.SendCommand(fakeCommand);
					});
			}
		}
	}
}
