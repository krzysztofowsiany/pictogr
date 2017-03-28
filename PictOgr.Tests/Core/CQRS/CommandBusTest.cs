using System;
using Autofac;
using PictOgr.Core.AutoFac;
using PictOgr.Core.CQRS.Bus;
using Xunit;
using Shouldly;
using FakeItEasy;
using PictOgr.Core.CQRS.Command;

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
                        var fakeCommand = A.Fake<ICommand>();
                        commandBus.SendCommand(fakeCommand);
                    });
            }
        }
    }
}
