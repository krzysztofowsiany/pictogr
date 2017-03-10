﻿using System;
using Autofac;
using Xunit;
using Shouldly;
using FakeItEasy;
using PictOgr.Core.AutoFac;
using PictOgr.Core.CQRS.Command;

namespace PictOgr.Tests.Core.CQRS
{
	public class command_bus_test
	{
		private IContainer container;

		public command_bus_test()
		{
			container = Container.CreateBuilder().Build();
		}

		[Fact]
		public void test_command_bus()
		{
			//Arragne
			using (var scope = container.BeginLifetimeScope())
			{
				//Act
				var command_bus = scope.Resolve<ICommandBus>();

				//Assert
				command_bus.ShouldBeOfType<CommandBus>();
			}
		}

		[Fact]
		public void test_simple_test_command_throw_exception()
		{
			//Arragne
			using (var scope = container.BeginLifetimeScope())
			{
				//Act
				var command_bus = scope.Resolve<ICommandBus>();

				//Assert
				Should.Throw<Exception>(() =>
				{
					command_bus.SendCommand(new CommandTest());
				});
			}
		}
	}
}
