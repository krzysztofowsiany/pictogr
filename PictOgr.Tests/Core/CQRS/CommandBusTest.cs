using System;
using Autofac;
using PictOgr.Core.AutoFac;
using Xunit;
using Shouldly;
using PictOgr.Core.CQRS.Command;
using PictOgr.Tests.Core.CQRS.Commands;

namespace PictOgr.Tests.Core.CQRS
{
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
					commandBus.SendCommand(new CommandTest());
				});
			}
		}
	}
}
